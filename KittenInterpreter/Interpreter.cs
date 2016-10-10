using System;
using Kitten;
using Antlr4.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using System.IO;
using static KittenInterpreter.Utility;
/*
Interpreter.cs

*/
namespace KittenInterpreter
{
    class Interpreter
    {
        string input;
        KittenGrammarLexer lexer;
        KittenGrammarParser parser;
        KittenGrammarParser.CompileUnitContext tree;
        KittenVisitor visitor;
        public Interpreter(string filename)
        {
            var gmem = KittenVisitor.globalMemory;
            gmem.Add("print", new DynObj { t = vType.Function,FuncVal = new function { t = function.funcType.Builtin, BuiltinIMP = BI_print} });
            gmem.Add("println", new DynObj { t = vType.Function, FuncVal = new function { t = function.funcType.Builtin, BuiltinIMP = BI_println } });
            gmem.Add("number", new DynObj { t = vType.Function, FuncVal = new function { t = function.funcType.Builtin, BuiltinIMP = BI_numberCast } });
            gmem.Add("input", new DynObj { t = vType.Function, FuncVal = new function { t = function.funcType.Builtin, BuiltinIMP = BI_input } });
            input = File.ReadAllText(filename);
            lexer = new KittenGrammarLexer(new AntlrInputStream(input));
            parser = new KittenGrammarParser(new CommonTokenStream(lexer));
            tree = parser.compileUnit();
            visitor = new KittenVisitor(new Dictionary<string, DynObj>());
           
        }

        public static DynObj BI_print(List<DynObj> args)
        {
            foreach (var item in args)
            {
                Console.Write(item.ToString());
            }
            return DNull();
        }

        public static DynObj BI_println(List<DynObj> args)
        {
            BI_print(args);
            Console.WriteLine();
            return DNull();
        }

        public static DynObj BI_numberCast(List<DynObj> args)
        {
            DynObj obj = args[0];
            switch (obj.t)
            {
                case vType.Number:
                    return obj;
                case vType.Bool:
                    if (obj.BoolVal == true)
                    {
                        return DNumber(1);
                    }
                    else
                    {
                        return DNumber(0);
                    }
                case vType.String:
                    return DNumber(int.Parse(obj.StringVal));
                case vType.Function:
                    return DNumber(0);
                case vType.Null:
                    return DNumber(0);
            }
            return DNumber(0);
        }

        public static DynObj BI_input(List<DynObj> args)
        {
            var str = Console.ReadLine();
            return DString(str);
        }

        public void Start()
        {
            try
           {
                visitor.Visit(tree);
           }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }


    }
    enum vType
    {
        Number,
        Bool,
        String,
        Function,
        Null
    }
    static class Utility
    {
        public static DynObj DNumber(double val)
        {
            return new DynObj { t = vType.Number, NumberVal = val };
        }
        public static DynObj DString(string val)
        {
            return new DynObj { t = vType.String, StringVal = val };
        }
        public static DynObj DBool(bool val)
        {
            return new DynObj { t = vType.Bool, BoolVal = val };
        }
        public static DynObj DFunction() //TODO
        {
            return new DynObj();
        }
        public static DynObj DNull()
        {
            return new DynObj { t = vType.Null };
        }
        public static void ReportError(string type,string reason,int line)
        {
            Console.WriteLine($"{type} occured. \nReason:{reason}\nAt line:{line}");
            throw new RuntimeException();
        }
        
    }
    class RuntimeException : Exception
    {
        public override string Message
        {
            get
            {
                return "Runtime error occured. Interpretetion stopped.";
            }
        }
    }
    struct DynObj
    {
        public vType t;
        public double NumberVal;
        public string StringVal;
        public bool BoolVal;
        public function FuncVal;
        public override string ToString()
        {
            switch (t)
            {
                case vType.Number:
                    return NumberVal.ToString();
                case vType.Bool:
                    return BoolVal.ToString();
                case vType.String:
                    return StringVal;
                case vType.Function:
                    return "Function";
                case vType.Null:
                    return "Null";
            }
            return "Unrecongized";
        }

        public string typeName
        {
            get {
                switch (t)
                {
                    case vType.Number:
                        return "Number";
                    case vType.Bool:
                        return "Bool";
                    case vType.String:
                        return "String";
                    case vType.Function:
                        return "Function";
                    case vType.Null:
                        return "Null";
                }
                return "No Value";
            }
        }

    }

    struct function
    {
        public enum funcType
        {
            User,
            Builtin
        }
        public funcType t;
        public List<string> parameters;
        public int parameterCount {
            get {
                return parameters.Count();
            }
        }
        public Func<List<DynObj>, DynObj> BuiltinIMP;
        public KittenGrammarParser.StatementListContext IMP;
    }

    class KittenVisitor : KittenGrammarBaseVisitor<DynObj>
    {
        public static Dictionary<string, DynObj> globalMemory =  new Dictionary<string, DynObj>();
        public Dictionary<string, DynObj> memory;
        public KittenVisitor(Dictionary<string,DynObj> mem)
        {
            memory = mem;
            foreach (var item in globalMemory)
            {
                mem.Add(item.Key, item.Value);
            }
        }
        public override DynObj VisitDeclStatement([NotNull] KittenGrammarParser.DeclStatementContext context)
        {
            var name = context.ID().Symbol.Text;
            if (memory.ContainsKey(name))
            {
                ReportError("DuplicateDeclarationError", $"you have already declared identifier {name}", context.start.Line);
            }
            else
            {
                DynObj value = Visit(context.expr());
                memory.Add(name, value);
            }

            return DNull();
        }

        public override DynObj VisitAssignStatement([NotNull] KittenGrammarParser.AssignStatementContext context)
        {
            var name = context.ID().Symbol.Text;
            if (!memory.ContainsKey(name))
            {
                ReportError("UnrecognizedIdentifierError", $"identifier name {name} not found in the context", context.start.Line);
            }
            else
            {
                DynObj value = Visit(context.expr());
                memory[name] = value;
            }
            return base.VisitAssignStatement(context);
        }

        public override DynObj VisitIdentifierExpr([NotNull] KittenGrammarParser.IdentifierExprContext context)
        {
            var name = context.ID().Symbol.Text;
            if (!memory.ContainsKey(name))
            {
                ReportError("UnrecognizedIdentifierError", $"identifier name {name} not found in the context", context.start.Line);
            }
            else
            {
                return memory[name];
            }
            return DNull();
        }

        public override DynObj VisitIntegerLiteralExpr([NotNull] KittenGrammarParser.IntegerLiteralExprContext context)
        {
            return DNumber(int.Parse(context.IntegerLiteral().Symbol.Text));
        }

        public override DynObj VisitStringLiteralExpr([NotNull] KittenGrammarParser.StringLiteralExprContext context)
        {
            return DString(context.StringLiteral().Symbol.Text);
        }

        public override DynObj VisitBooleanLiteralExpr([NotNull] KittenGrammarParser.BooleanLiteralExprContext context)
        {
            return DBool(bool.Parse(context.BooleanLiteral().Symbol.Text));
        }

        public override DynObj VisitBlockLiteral([NotNull] KittenGrammarParser.BlockLiteralContext context)
        {
            var imp = context.statementList();
            DynObj result = new DynObj { t = vType.Function, FuncVal = new function { parameters = new List<string>(), IMP = imp } };
            if (context.identifierList() != null)
            {
                var list = context.identifierList();
                foreach (var idName in list.ID())
                {
                    result.FuncVal.parameters.Add(idName.Symbol.Text);
                }
            }
            return result;
        }

        public override DynObj VisitArithmaticExpr([NotNull] KittenGrammarParser.ArithmaticExprContext context)
        {
            var LHS = Visit(context.left);
            var RHS = Visit(context.right);
            var op = context.op.Text;
            if (LHS.t == vType.Number && RHS.t == vType.Number)
            {
                switch (op)
                {
                    case "+":
                        return DNumber(LHS.NumberVal + RHS.NumberVal);
                    case "-":
                        return DNumber(LHS.NumberVal - RHS.NumberVal);
                    case "*":
                        return DNumber(LHS.NumberVal * RHS.NumberVal);
                    case "/":
                        return DNumber(LHS.NumberVal / RHS.NumberVal);
                }
            }
            else if (LHS.t == vType.String && RHS.t == vType.String)
            {
                if (op == "+")
                {
                    return DString(LHS.StringVal + RHS.StringVal);
                }
            }
            else
            {
                ReportError("InvalidTypeError", $"LHS type {LHS.typeName} and RHS type {RHS.typeName} used on operator \"{op}\"",context.start.Line);
            }
            return base.VisitArithmaticExpr(context);
        }

        public override DynObj VisitBooleanExpr([NotNull] KittenGrammarParser.BooleanExprContext context)
        {
            var LHS = Visit(context.left);
            var RHS = Visit(context.right);
            var op = context.op.Text;
            if (LHS.t == RHS.t)
            {
                if (LHS.t == vType.Number)
                {
                    switch (op)
                    {
                        case "==":
                            return DBool(RHS.NumberVal == LHS.NumberVal);
                        case "!=":
                            return DBool(RHS.NumberVal != LHS.NumberVal);
                        case ">=":
                            return DBool(RHS.NumberVal >= LHS.NumberVal);
                        case "<=":
                            return DBool(RHS.NumberVal <= LHS.NumberVal);
                        case ">":
                            return DBool(RHS.NumberVal > LHS.NumberVal);
                        case "<":
                            return DBool(RHS.NumberVal < LHS.NumberVal);
                    }
                }
                if (LHS.t == vType.Bool)
                {
                    switch (op)
                    {
                        case "==":
                            return DBool(LHS.BoolVal == RHS.BoolVal);
                        case "!=":
                            return DBool(LHS.BoolVal != RHS.BoolVal);
                        default:
                            ReportError("InvalidOperatorError",$"operator {op} used in LHS and RHS type {LHS.typeName}",context.start.Line);
                            break;
                    }
                }
                if (LHS.t == vType.String)
                {
                    switch (op)
                    {
                        case "==":
                            return DBool(LHS.StringVal == RHS.StringVal);
                        case "!=":           
                            return DBool(LHS.StringVal != RHS.StringVal);
                        default:
                            ReportError("InvalidOperatorError", $"operator {op} used in LHS and RHS type {LHS.typeName}", context.start.Line);
                            break;
                    }
                }
                if (LHS.t == vType.Null)
                {
                    switch (op)
                    {
                        case "==":
                            return DBool(true);
                        case "!=":
                            return DBool(false);
                        default:
                            ReportError("InvalidOperatorError", $"operator {op} used in LHS and RHS type {LHS.typeName}", context.start.Line);
                            break;
                    }
                }
            }
            else
            {
                ReportError("InvalidTypeError", $"LHS type {LHS.typeName} and RHS type {RHS.typeName} used on operator \"{op}\"", context.start.Line);
            }
            return base.VisitBooleanExpr(context);
        }

        public override DynObj VisitFunctionCallExpr([NotNull] KittenGrammarParser.FunctionCallExprContext context)
        {
            var name = context.ID().Symbol.Text;
            if (!memory.ContainsKey(name))
            {
                ReportError("UnrecognizedIdentifierError", $"identifier name {name} not found in the context", context.start.Line);
            }
            var paraList = memory[name].FuncVal.parameters;
            var valueList = new List<DynObj>();
            if (context.exprList() != null)
            {
                foreach (var item in context.exprList().expr())
                {
                    valueList.Add(Visit(item));
                }
            }
            if (memory[name].FuncVal.t == function.funcType.User)
            {
                if (paraList.Count != valueList.Count)
                {
                    ReportError("ArgumentNumberMismatchError", $"expected {paraList.Count}, but called with {valueList.Count}", context.start.Line);
                }
                Dictionary<string, DynObj> contextMem = new Dictionary<string, DynObj>();
                for (int i = 0; i < paraList.Count; i++)
                {
                    contextMem.Add(paraList[i], valueList[i]);
                }
                var funcVisitor = new KittenVisitor(contextMem);
                return funcVisitor.Visit(memory[name].FuncVal.IMP);
            }
            if (memory[name].FuncVal.t == function.funcType.Builtin)
            {
                return memory[name].FuncVal.BuiltinIMP(valueList);
            }
            return base.VisitFunctionCallExpr(context);
        }
    }

    
}
