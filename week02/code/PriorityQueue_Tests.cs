using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several values with distinct priorities (added out of priority order),
    // then dequeue them all. Includes the highest priority item added LAST so the test also
    // checks that the final element in the list is considered.
    // Expected Result: Items come out from highest priority to lowest: "high", "medium", "low".
    // Defect(s) Found: Two defects. (1) Dequeue never removed the item, so the same value was
    // returned on every call. (2) The search loop stopped one element early (index < Count - 1),
    // so the highest priority item never won when it was the last item in the list.
    public void TestPriorityQueue_HighestPriorityRemovedFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 2);
        priorityQueue.Enqueue("high", 3); // highest priority, added last

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items that share the same highest priority, along with a
    // couple of lower priority items, then dequeue everything.
    // Expected Result: Among equal priorities, the one enqueued first comes out first (FIFO):
    // "first", "second", "third", then the lower priority "last".
    // Defect(s) Found: Defect. Dequeue used ">=" when comparing priorities, which selected the
    // LAST item among equal priorities instead of the first, breaking the FIFO tie-break rule.
    public void TestPriorityQueue_SamePriorityIsFifo()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 5);
        priorityQueue.Enqueue("last", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
        Assert.AreEqual("last", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message
    // "The queue is empty."
    // Defect(s) Found: None. The empty-queue guard already behaves correctly.
    public void TestPriorityQueue_EmptyThrows()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue values whose priorities rise and fall (not sorted), mixing a repeated
    // highest priority with lower ones, then dequeue all of them.
    // Expected Result: Highest priority first with FIFO tie-break, then descending priority:
    // "a" (10), "d" (10), "b" (7), "c" (3).
    // Defect(s) Found: None additional beyond those above; this confirms the overall ordering
    // once the removal, loop bound, and tie-break defects are fixed.
    public void TestPriorityQueue_MixedPriorityOrdering()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 10);
        priorityQueue.Enqueue("b", 7);
        priorityQueue.Enqueue("c", 3);
        priorityQueue.Enqueue("d", 10);

        Assert.AreEqual("a", priorityQueue.Dequeue());
        Assert.AreEqual("d", priorityQueue.Dequeue());
        Assert.AreEqual("b", priorityQueue.Dequeue());
        Assert.AreEqual("c", priorityQueue.Dequeue());
    }
}