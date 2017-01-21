using System;
using System.Collections;
namespace ExpressionToIL
{
	public class ExpressionEval
	{
		public static void Main(String[] args)
		{
			//Build Exp tree
			var exp = new BinaryExpression();
			var lExp = new NumericExpression(20);

			var rExp = new BinaryExpression();
			rExp.LExp = new NumericExpression(30);

			var uExp = new UnaryExpression();
			uExp.Exp = new NumericExpression(3);
			uExp.Opr = Operator.SUB;

			rExp.RExp = uExp;			
			rExp.Opr = Operator.DIV;

			exp.LExp = lExp;
			exp.RExp = rExp;
			exp.Opr = Operator.ADD;

			//Start execution
			Stack opndStack = new Stack();
			IVisitor visitor = new ExpressionEvaluator();
			exp.Accept(visitor, opndStack);
			Console.WriteLine("Result -> " + opndStack.Pop());

		}
			
	}

	public interface Expression : IVisitable
	{ 
	}

	public enum Operator
	{
		ADD, SUB, DIV, MUL
	}

	public class BinaryExpression : Expression
	{				
		public Expression LExp;
		public Expression RExp;
		public Operator Opr;

		public void Accept(IVisitor visitor, Stack opndStack)
		{
			visitor.Visit(this, opndStack);
		}
	}

	public class NumericExpression : Expression
	{
		public double Value;

		public NumericExpression(double value)
		{
			this.Value = value;
		}

		public void Accept(IVisitor visitor, Stack opndStack)
		{
			visitor.Visit(this, opndStack);
		}
	}

	public class UnaryExpression : Expression
	{
		public Expression Exp;
		public Operator Opr;
		

		public void Accept(IVisitor visitor, Stack opndStack)
		{
			visitor.Visit(this, opndStack);
		}
	}



	public interface IVisitor
	{				
		void Visit(BinaryExpression exp, Stack opndStack);
		void Visit(UnaryExpression exp, Stack opndStack);
		void Visit(NumericExpression exp, Stack opndStack);
	}

	public class ExpressionEvaluator : IVisitor
	{

		public void Visit(NumericExpression exp, Stack opndStack)
		{
			Console.WriteLine("Push: " + exp.Value);
			opndStack.Push(exp.Value);
		}

		public void Visit(BinaryExpression exp, Stack opndStack)
		{
			exp.LExp.Accept(this, opndStack);
			exp.RExp.Accept(this, opndStack);
			switch (exp.Opr)
			{
				case Operator.ADD:
					var rightOpnd = (Double)opndStack.Pop();
					var leftOpnd = (Double)opndStack.Pop();
					Console.WriteLine("POP: " + rightOpnd);
					Console.WriteLine("POP: " + leftOpnd);
					var result = leftOpnd + rightOpnd;
					opndStack.Push(result);
					break;

				case Operator.SUB:
					rightOpnd = (Double)opndStack.Pop();
					leftOpnd = (Double)opndStack.Pop();
					Console.WriteLine("POP: " + rightOpnd);
					Console.WriteLine("POP: " + leftOpnd);
					result = leftOpnd - rightOpnd;
					opndStack.Push(result);
					Console.WriteLine("Push: " + result);
					break;

				case Operator.DIV:
					rightOpnd = (Double)opndStack.Pop();
					leftOpnd = (Double)opndStack.Pop();
					Console.WriteLine("POP: " + rightOpnd);
					Console.WriteLine("POP: " + leftOpnd);
					result = leftOpnd / rightOpnd;
					opndStack.Push(result);
					Console.WriteLine("Push: " + result);
					break;

				case Operator.MUL:
					rightOpnd = (Double)opndStack.Pop();
					leftOpnd = (Double)opndStack.Pop();
					Console.WriteLine("POP: " + rightOpnd);
					Console.WriteLine("POP: " + leftOpnd);
					result = leftOpnd * rightOpnd;
					opndStack.Push(result);
					Console.WriteLine("Push: " + result);
					break;
			}
		}

		public void Visit(UnaryExpression exp, Stack opndStack)
		{
			exp.Exp.Accept(this, opndStack);
			switch (exp.Opr)
			{
				case Operator.ADD:
					var opnd = (Double)opndStack.Pop();
					Console.WriteLine("POP: " + opnd);
					opndStack.Push(opnd);
					break;

				case Operator.SUB:
					opnd = (Double)opndStack.Pop();
					Console.WriteLine("POP: " + opnd);
					opndStack.Push(-opnd);
					break;
			}
		}
	}
	public interface IVisitable
	{
		void Accept(IVisitor visitor, Stack opndStack);
	}
}
