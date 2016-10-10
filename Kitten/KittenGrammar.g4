grammar KittenGrammar;

//A BIG FUCKYOU TO GITHUB FOR DELETING MY WHOLE PROJECT

/*
 * Parser Rules
 */
	
statement
	: declStatement
	| assignStatement
	| exprStatement
	;

declStatement
	: 'var' ID '=' expr
	;

assignStatement
	: ID '=' expr
	;

exprStatement
	: expr
	;

statementList
	: (statement ';')*
	;

identifierList
	: ID*
	;

expr
	: ID #identifierExpr
	| IntegerLiteral #integerLiteralExpr
	| StringLiteral #stringLiteralExpr
	| BooleanLiteral #booleanLiteralExpr
	| blockLiteral #blockExpr
	| '(' expr ')' #parenExpr
	| left=expr op=('*' | '/') right=expr #arithmaticExpr
	| left=expr op=('+' | '-') right=expr #arithmaticExpr
	| left=expr op=('=='|'>='|'<='|'!='|'>'|'<') right=expr #booleanExpr
	| ID '(' exprList ')' #functionCallExpr
	| ID '(' ')' #functionCallExpr
	;

blockLiteral
	:  ('[' identifierList '}')? '{' statementList '}'
	;

exprList
	: expr (',' expr)*
	;

compileUnit
	: statementList	EOF
	;

/*
 * Lexer Rules
 */



IntegerLiteral : [0-9]+ ; 
BooleanLiteral : 'true' | 'false';
StringLiteral: '"' (ESC|.)*? '"' ; 
fragment ESC : '\\"' | '\\\\' ; 
ID : [a-zA-Z]+ ; 


WS
	: ('\r'
	| '\n'
	| ' ') -> channel(HIDDEN)
	;
