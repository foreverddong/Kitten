# Kitten
###version 0.01
Another toy dynamic language


##Features
__Dynamic__: declare variables with 'var' and don't bother about types!

__Function as a basic type__:  
var printSum = [vala,valb]{print(vala + valb);};

printSum(7,6); //output:13

var b = printSum; //Direct assign the 'Function' value

b(1,5); //output:6


