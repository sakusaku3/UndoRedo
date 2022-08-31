using System;
using System.Reactive.Linq;
using NUnit.Framework;

namespace UndoRedo.Test
{
	public class CommandOwnerTest
	{
		[Test]
		public void UndoRedoTest()
		{
			var takeshi = new Person("Takeshi", 12);
			var target = new CommandOwner();

			target.Execute(new SetValueCommand<int>(takeshi.Age, 13, x => takeshi.Age = x));
			takeshi.Age.Is(13);

			target.Execute(new SetValueCommand<int>(takeshi.Age, 40, x => takeshi.Age = x));
			takeshi.Age.Is(40);

			target.Undo();
			takeshi.Age.Is(13);

			target.Undo();
			takeshi.Age.Is(12);

			target.Undo();
			takeshi.Age.Is(12);

			target.Redo();
			takeshi.Age.Is(13);

			target.Redo();
			takeshi.Age.Is(40);

			target.Redo();
			takeshi.Age.Is(40);
		}

		[Test]
		public void CanUndoRedoTest()
		{
			var takeshi = new Person("Takeshi", 12);

			var target = new CommandOwner();
			target.CanUndo.Value.IsFalse();
			target.CanRedo.Value.IsFalse();

			var canUndoValue = false;
			target.CanUndo.Subscribe(x => canUndoValue = x);
			var canRedoValue = false;
			target.CanRedo.Subscribe(x => canRedoValue = x);
			target.Execute(new SetValueCommand<int>(takeshi.Age, 13, x => takeshi.Age = x));

			canUndoValue.IsTrue();
			canRedoValue.IsFalse();

			target.Undo();
			canUndoValue.IsFalse();
			canRedoValue.IsTrue();

			target.Redo();
			canUndoValue.IsTrue();
			canRedoValue.IsFalse();
		}
	}
}