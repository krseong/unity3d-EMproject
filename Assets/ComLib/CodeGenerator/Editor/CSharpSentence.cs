using System;

namespace ComLib
{
	public class CSharpSentence
	{
		public static readonly string USING_UnityEngine = "UnityEngine";
		public static readonly string USING_Collections = "System.Collections";
		private static readonly string BRACE_OPEN = "{";
		private static readonly string BRACE_CLOSE = "}";

		public static string USING_Layout ( string libaryName )
		{
			return string.Format ("using {0} ;\n", libaryName);
		}

		public static string CLASS_Layout ( string className, string body )
		{
			return string.Format (
				"public class {0}\n" +
				"{2}\n" +
				"{1}" +
				"{3}\n",	
				className,	
				body, 
				BRACE_OPEN, 
				BRACE_CLOSE);
		}

		public static string METHOD_RESULT_Layout ( string keyword, string className, string methodName, string body )
		{
			return string.Format (
				"\tpublic {0} {1} {2} ( {1} result, {1} owner, params {1}[] other )\n" +
				"\t{4}\n" +
				"\t\tresult = new {1}(owner) ;\n" +
				"\t\tresult.{3} ;\n" +
				"\t\treturn result ;\n" +
				"\t{5}\n", 
				keyword,
				className, 
				methodName,
				body, 
				BRACE_OPEN, 
				BRACE_CLOSE);
		}
	}
}