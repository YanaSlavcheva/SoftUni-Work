var myConsoleModule = (function(){
    function writeLine(){
        if(arguments.length > 1) {
            console.log(writeLineArgs(arguments));
        }
        else {
            console.log(arguments[0]);
        }
    }

    function writeError(){
        if(arguments.length > 1) {
            console.error(writeLineArgs(arguments));
        }
        else {
            console.error(arguments[0]);
        }
    }

    function writeWarning(){
        if(arguments.length > 1) {
            console.warn(writeLineArgs(arguments));
        }
        else {
            console.warn(arguments[0]);
        }
    }

    function writeLineArgs(arguments){
        var pattern = arguments[0]; //"Message: {0}"
        var placeholders = pattern.match(/{[0-9]}/g); //array of placeholders

        var output = []; //array with replaced placeholders
        var outputPrint;
        output[0] = pattern.replace(placeholders[0], arguments[1]);
        outputPrint = output[0];
        if(placeholders.length > 1) {
            for (var i = 1; i < placeholders.length; i++) {
                output[i] = output[i - 1].replace(placeholders[i], arguments[i + 1]);
                outputPrint = output[i];
            }
        }


        return outputPrint.toString();
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning:writeWarning
    }

}())

myConsoleModule.writeLine("Message: hello");
myConsoleModule.writeLine("Message: {0}{1}", "hello ", "world");
myConsoleModule.writeError("Error: {0}", "A fatal error has occurred.");
myConsoleModule.writeWarning("Warning: {0}", "You are not allowed to do that!");


