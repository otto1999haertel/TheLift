Coding challenge:
https://www.codewars.com/kata/58905bfa1decb981da00009e
Test Cases:
https://www.codewars.com/kata/58905bfa1decb981da00009e/train/csharp

queues: a list of queues of people for all floors of the building. Queue index [0] is the "head" of the queue capacity: maximum number of people allowed in the lift Your code here: Return a list of all floors that the Lift stopped at (in the order visited!) Start and End is 0 Challenge Focus: Quues (First In First Out)

The Lift never changes direction until there are no more people wanting to get on/off in the direction it is already travelling If it was going up then it may continue up to collect the highest floor person wanting to go down If it was going down then it may continue down to collect the lowest floor person wanting to go up If the lift is empty, and no people are waiting, then it will return to the ground floor

People are in "queues" that represent their order of arrival to wait for the Lift Entry is according to the "queue" order, but those unable to enter do not block those behind them that can Only people going the same direction as the Lift may enter it
