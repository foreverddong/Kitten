//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\ddong\documents\visual studio 2015\Projects\Kitten\Kitten\KittenGrammar.g4 by ANTLR 4.5.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Kitten {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.3")]
[System.CLSCompliant(false)]
public partial class KittenGrammarLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, IntegerLiteral=33, BooleanLiteral=34, StringLiteral=35, ID=36, 
		WS=37;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "T__24", 
		"T__25", "T__26", "T__27", "T__28", "T__29", "T__30", "T__31", "IntegerLiteral", 
		"BooleanLiteral", "StringLiteral", "ESC", "ID", "WS"
	};


	public KittenGrammarLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'var'", "'='", "'while'", "'('", "')'", "'if'", "'else'", "'for'", 
		"';'", "'return'", "'*'", "'/'", "'%'", "'+'", "'-'", "'not'", "'!'", 
		"'=='", "'>='", "'<='", "'!='", "'>'", "'<'", "'and'", "'or'", "'&&'", 
		"'||'", "'['", "']'", "'{'", "'}'", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, "IntegerLiteral", 
		"BooleanLiteral", "StringLiteral", "ID", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "KittenGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\'\xD4\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x3\x2\x3\x2\x3\x2\x3"+
		"\x2\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x6"+
		"\x3\x6\x3\a\x3\a\x3\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3"+
		"\n\x3\n\x3\v\x3\v\x3\v\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\r\x3\r\x3\xE\x3"+
		"\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x11\x3\x11\x3\x12\x3\x12"+
		"\x3\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x3\x15\x3\x15\x3\x15\x3\x16"+
		"\x3\x16\x3\x16\x3\x17\x3\x17\x3\x18\x3\x18\x3\x19\x3\x19\x3\x19\x3\x19"+
		"\x3\x1A\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1C\x3\x1D"+
		"\x3\x1D\x3\x1E\x3\x1E\x3\x1F\x3\x1F\x3 \x3 \x3!\x3!\x3\"\x6\"\xAD\n\""+
		"\r\"\xE\"\xAE\x3#\x3#\x3#\x3#\x3#\x3#\x3#\x3#\x3#\x5#\xBA\n#\x3$\x3$\x3"+
		"$\a$\xBF\n$\f$\xE$\xC2\v$\x3$\x3$\x3%\x3%\x3%\x3%\x5%\xCA\n%\x3&\x6&\xCD"+
		"\n&\r&\xE&\xCE\x3\'\x3\'\x3\'\x3\'\x3\xC0\x2\x2(\x3\x2\x3\x5\x2\x4\a\x2"+
		"\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2\r"+
		"\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14\'\x2"+
		"\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19\x31\x2\x1A\x33\x2\x1B\x35\x2\x1C"+
		"\x37\x2\x1D\x39\x2\x1E;\x2\x1F=\x2 ?\x2!\x41\x2\"\x43\x2#\x45\x2$G\x2"+
		"%I\x2\x2K\x2&M\x2\'\x3\x2\x5\x3\x2\x32;\x4\x2\x43\\\x63|\x5\x2\v\f\xF"+
		"\xF\"\"\xD8\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t"+
		"\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11"+
		"\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2"+
		"\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2"+
		"\x2\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2"+
		"\x2)\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31"+
		"\x3\x2\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2"+
		"\x2\x39\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2"+
		"\x41\x3\x2\x2\x2\x2\x43\x3\x2\x2\x2\x2\x45\x3\x2\x2\x2\x2G\x3\x2\x2\x2"+
		"\x2K\x3\x2\x2\x2\x2M\x3\x2\x2\x2\x3O\x3\x2\x2\x2\x5S\x3\x2\x2\x2\aU\x3"+
		"\x2\x2\x2\t[\x3\x2\x2\x2\v]\x3\x2\x2\x2\r_\x3\x2\x2\x2\xF\x62\x3\x2\x2"+
		"\x2\x11g\x3\x2\x2\x2\x13k\x3\x2\x2\x2\x15m\x3\x2\x2\x2\x17t\x3\x2\x2\x2"+
		"\x19v\x3\x2\x2\x2\x1Bx\x3\x2\x2\x2\x1Dz\x3\x2\x2\x2\x1F|\x3\x2\x2\x2!"+
		"~\x3\x2\x2\x2#\x82\x3\x2\x2\x2%\x84\x3\x2\x2\x2\'\x87\x3\x2\x2\x2)\x8A"+
		"\x3\x2\x2\x2+\x8D\x3\x2\x2\x2-\x90\x3\x2\x2\x2/\x92\x3\x2\x2\x2\x31\x94"+
		"\x3\x2\x2\x2\x33\x98\x3\x2\x2\x2\x35\x9B\x3\x2\x2\x2\x37\x9E\x3\x2\x2"+
		"\x2\x39\xA1\x3\x2\x2\x2;\xA3\x3\x2\x2\x2=\xA5\x3\x2\x2\x2?\xA7\x3\x2\x2"+
		"\x2\x41\xA9\x3\x2\x2\x2\x43\xAC\x3\x2\x2\x2\x45\xB9\x3\x2\x2\x2G\xBB\x3"+
		"\x2\x2\x2I\xC9\x3\x2\x2\x2K\xCC\x3\x2\x2\x2M\xD0\x3\x2\x2\x2OP\ax\x2\x2"+
		"PQ\a\x63\x2\x2QR\at\x2\x2R\x4\x3\x2\x2\x2ST\a?\x2\x2T\x6\x3\x2\x2\x2U"+
		"V\ay\x2\x2VW\aj\x2\x2WX\ak\x2\x2XY\an\x2\x2YZ\ag\x2\x2Z\b\x3\x2\x2\x2"+
		"[\\\a*\x2\x2\\\n\x3\x2\x2\x2]^\a+\x2\x2^\f\x3\x2\x2\x2_`\ak\x2\x2`\x61"+
		"\ah\x2\x2\x61\xE\x3\x2\x2\x2\x62\x63\ag\x2\x2\x63\x64\an\x2\x2\x64\x65"+
		"\au\x2\x2\x65\x66\ag\x2\x2\x66\x10\x3\x2\x2\x2gh\ah\x2\x2hi\aq\x2\x2i"+
		"j\at\x2\x2j\x12\x3\x2\x2\x2kl\a=\x2\x2l\x14\x3\x2\x2\x2mn\at\x2\x2no\a"+
		"g\x2\x2op\av\x2\x2pq\aw\x2\x2qr\at\x2\x2rs\ap\x2\x2s\x16\x3\x2\x2\x2t"+
		"u\a,\x2\x2u\x18\x3\x2\x2\x2vw\a\x31\x2\x2w\x1A\x3\x2\x2\x2xy\a\'\x2\x2"+
		"y\x1C\x3\x2\x2\x2z{\a-\x2\x2{\x1E\x3\x2\x2\x2|}\a/\x2\x2} \x3\x2\x2\x2"+
		"~\x7F\ap\x2\x2\x7F\x80\aq\x2\x2\x80\x81\av\x2\x2\x81\"\x3\x2\x2\x2\x82"+
		"\x83\a#\x2\x2\x83$\x3\x2\x2\x2\x84\x85\a?\x2\x2\x85\x86\a?\x2\x2\x86&"+
		"\x3\x2\x2\x2\x87\x88\a@\x2\x2\x88\x89\a?\x2\x2\x89(\x3\x2\x2\x2\x8A\x8B"+
		"\a>\x2\x2\x8B\x8C\a?\x2\x2\x8C*\x3\x2\x2\x2\x8D\x8E\a#\x2\x2\x8E\x8F\a"+
		"?\x2\x2\x8F,\x3\x2\x2\x2\x90\x91\a@\x2\x2\x91.\x3\x2\x2\x2\x92\x93\a>"+
		"\x2\x2\x93\x30\x3\x2\x2\x2\x94\x95\a\x63\x2\x2\x95\x96\ap\x2\x2\x96\x97"+
		"\a\x66\x2\x2\x97\x32\x3\x2\x2\x2\x98\x99\aq\x2\x2\x99\x9A\at\x2\x2\x9A"+
		"\x34\x3\x2\x2\x2\x9B\x9C\a(\x2\x2\x9C\x9D\a(\x2\x2\x9D\x36\x3\x2\x2\x2"+
		"\x9E\x9F\a~\x2\x2\x9F\xA0\a~\x2\x2\xA0\x38\x3\x2\x2\x2\xA1\xA2\a]\x2\x2"+
		"\xA2:\x3\x2\x2\x2\xA3\xA4\a_\x2\x2\xA4<\x3\x2\x2\x2\xA5\xA6\a}\x2\x2\xA6"+
		">\x3\x2\x2\x2\xA7\xA8\a\x7F\x2\x2\xA8@\x3\x2\x2\x2\xA9\xAA\a.\x2\x2\xAA"+
		"\x42\x3\x2\x2\x2\xAB\xAD\t\x2\x2\x2\xAC\xAB\x3\x2\x2\x2\xAD\xAE\x3\x2"+
		"\x2\x2\xAE\xAC\x3\x2\x2\x2\xAE\xAF\x3\x2\x2\x2\xAF\x44\x3\x2\x2\x2\xB0"+
		"\xB1\av\x2\x2\xB1\xB2\at\x2\x2\xB2\xB3\aw\x2\x2\xB3\xBA\ag\x2\x2\xB4\xB5"+
		"\ah\x2\x2\xB5\xB6\a\x63\x2\x2\xB6\xB7\an\x2\x2\xB7\xB8\au\x2\x2\xB8\xBA"+
		"\ag\x2\x2\xB9\xB0\x3\x2\x2\x2\xB9\xB4\x3\x2\x2\x2\xBA\x46\x3\x2\x2\x2"+
		"\xBB\xC0\a$\x2\x2\xBC\xBF\x5I%\x2\xBD\xBF\v\x2\x2\x2\xBE\xBC\x3\x2\x2"+
		"\x2\xBE\xBD\x3\x2\x2\x2\xBF\xC2\x3\x2\x2\x2\xC0\xC1\x3\x2\x2\x2\xC0\xBE"+
		"\x3\x2\x2\x2\xC1\xC3\x3\x2\x2\x2\xC2\xC0\x3\x2\x2\x2\xC3\xC4\a$\x2\x2"+
		"\xC4H\x3\x2\x2\x2\xC5\xC6\a^\x2\x2\xC6\xCA\a$\x2\x2\xC7\xC8\a^\x2\x2\xC8"+
		"\xCA\a^\x2\x2\xC9\xC5\x3\x2\x2\x2\xC9\xC7\x3\x2\x2\x2\xCAJ\x3\x2\x2\x2"+
		"\xCB\xCD\t\x3\x2\x2\xCC\xCB\x3\x2\x2\x2\xCD\xCE\x3\x2\x2\x2\xCE\xCC\x3"+
		"\x2\x2\x2\xCE\xCF\x3\x2\x2\x2\xCFL\x3\x2\x2\x2\xD0\xD1\t\x4\x2\x2\xD1"+
		"\xD2\x3\x2\x2\x2\xD2\xD3\b\'\x2\x2\xD3N\x3\x2\x2\x2\t\x2\xAE\xB9\xBE\xC0"+
		"\xC9\xCE\x3\x2\x3\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Kitten
