using System;
using System.Collections.Generic;
using MonoTouch.JavaScriptCore;

namespace CodePad.iOS.Engine
{
	public class ReplSession
	{	
		private readonly JSContext context;
		private readonly JSVirtualMachine vm;
		private readonly Queue<Statement> _history;

		public ReplSession ()
		{
			vm = new JSVirtualMachine ();
			context = new JSContext (vm);
			_history = new Queue<Statement> ();
		}

		public Statement Execute(Statement statement)
		{
			JSValue value = context.EvaluateScript (statement.Code);
			statement = statement.WithResult (value);
			_history.Enqueue (statement);
			return statement;
		}

		public IEnumerable<Statement> History { get{ return _history; }}
	}

	public class Statement
	{
		public Statement (string code) : this(code,null)
		{
		}

		public Statement (string code, JSValue result)
		{
			Code = code;
			ExecutionResult = result;
		}

		public Statement WithResult(JSValue result)
		{
			return new Statement (Code, result);
		}

		public string Code { get; private set; }
		public JSValue ExecutionResult { get; private set; }
		public bool Executed { get { return ExecutionResult != null; } }
	}

}

