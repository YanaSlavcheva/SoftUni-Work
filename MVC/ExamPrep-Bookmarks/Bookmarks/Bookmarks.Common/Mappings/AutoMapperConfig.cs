namespace Bookmarks.Common.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public class AutoMapperConfig
    {
        private static ICollection<Assembly> assemblies;

        public AutoMapperConfig(ICollection<Assembly> assemblies)
        {
            Assemblies = assemblies;
        }

        public static ICollection<Assembly> Assemblies
        {
            get
            {
                return assemblies;
            }

            private set
            {
                assemblies = value;
            }
        }

        public void Execute()
        {
            var types = assemblies
                .SelectMany(x => x.GetExportedTypes().ToList());

            this.LoadStandardFromMappings(types);
            this.LoadStandardToMappings(types);
            this.LoadCustomMappings(types);
        }

        private void LoadStandardFromMappings(IEnumerable<Type> types)
        {
            var maps = this.GetFromMaps(types);
            this.CreateMappings(maps);
        }

        private void LoadStandardToMappings(IEnumerable<Type> types)
        {
            var maps = this.GetToMaps(types);
            this.CreateMappings(maps);
        }

        private void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                             !t.IsAbstract &&
                             !t.IsInterface
                       select (IHaveCustomMappings)Activator.CreateInstance(t);

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }

        private IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
        {
            var fromMaps = from t in types
                           from i in t.GetInterfaces()
                           where i.IsGenericType &&
                                 i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                 !t.IsAbstract &&
                                 !t.IsInterface
                           select new TypesMap
                           {
                               Source = i.GetGenericArguments()[0],
                               Destination = t
                           };

            return fromMaps;
        }

        private IEnumerable<TypesMap> GetToMaps(IEnumerable<Type> types)
        {
            var toMaps = from t in types
                         from i in t.GetInterfaces()
                         where i.IsGenericType &&
                               i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                               !t.IsAbstract &&
                               !t.IsInterface
                         select new TypesMap
                         {
                             Source = t,
                             Destination = i.GetGenericArguments()[0]
                         };

            return toMaps;
        }

        private void CreateMappings(IEnumerable<TypesMap> maps)
        {
            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }
    }
}
