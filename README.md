# Kitten
###version 0.1
Another toy dynamic language


##Features
__Dynamic__: declare variables with 'var' and don't bother about types!

__Function as a basic type__:  
var printSum = [vala,valb]{print(vala + valb);};

printSum(7,6); //output:13

var b = printSum; //Direct assign the 'Function' value

b(1,5); //output:6

__Easier-to-understand keywords__:

supports C style && and ||

also word 'and' ,'or'!

##How to use

$KittenInterpreter.exe [sourceFile]

##Structure

Solution Kitten
    -- KittenGrammar 
    -- KittenInterpreter

