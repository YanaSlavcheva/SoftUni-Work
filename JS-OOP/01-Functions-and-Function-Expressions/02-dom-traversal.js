function traverseDom(){
	var selectors = ".birds",
		element = document.querySelector(selectors);

		function traverseElement(element, spacing){
			spacing = spacing || '	';

			var elementName = element.nodeName;
			var elementId = element.getAttribute("id");
			var elementClass = element.getAttribute("class");

			var output = elementName + ': ' + (elementId ? 'id="' + elementId + '"' : '') + (elementClass ? 'class="' + elementClass + '"' : '') + '\n';
			console.log(spacing, output);

			for (var i = 0; i < element.children.length; i++) {
				var child = element.children[i];
				if (child.nodeType === document.ELEMENT_NODE) {
					traverseElement(child, spacing + '	');
				}
			}
		}

		traverseElement(element, '	');
}

traverseDom();

