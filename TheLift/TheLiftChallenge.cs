namespace TheLift
{
    public class TheLiftChallenge
    {
        //https://www.codewars.com/kata/58905bfa1decb981da00009e
        //https://www.codewars.com/kata/58905bfa1decb981da00009e/train/csharp
        Queue<int> LiftQuee;
        List<int> stoppingFloors;
        //Einsteig Floor und Einsteigindex
        //List<Tuple<int,int>> passengersAlreadyTransported = new List<Tuple<int, int>>();
        int passengerTransported;
        int TotalPessengersCount;
        int iterationCycle;
        public TheLiftChallenge()
        {
            LiftQuee = new Queue<int>();
            stoppingFloors = new List<int>
            {
                0
            };
            passengerTransported = 0;
            TotalPessengersCount = 0;
            iterationCycle = 0;
        }
        public int[] TheLift(int[][] queues, int capacity)
        {
            //queues: a list of queues of people for all floors of the building.
            //Queue index [0] is the "head" of the queue
            //capacity:  maximum number of people allowed in the lift
            // Your code here: Return a list of all floors that the Lift stopped at (in the order visited!)
            //Start and End is 0
            // Challenge Focus: Quues (First In First Out)

            //The Lift never changes direction until there are no more people wanting to get on/off in the direction it is already travelling
            //If it was going up then it may continue up to collect the highest floor person wanting to go down
            //If it was going down then it may continue down to collect the lowest floor person wanting to go up
            //If the lift is empty, and no people are waiting, then it will return to the ground floor

            //People are in "queues" that represent their order of arrival to wait for the Lift
            //Entry is according to the "queue" order, but those unable to enter do not block those behind them that can
            //Only people going the same direction as the Lift may enter it

            //First: Go Up => check if want to go up => collect , if no => mark with go down tag


            SumUpTotalPassengers(queues);
            do
            {
                //GO UP
                GoUP(queues, capacity);

                //GO DOWN
                GoDown(queues, capacity);
                iterationCycle++;
            } while (TotalPessengersCount > passengerTransported);


            if (stoppingFloors.Last() != 0)
            {
                stoppingFloors.Add(0);
                //currentFloor = 0;
            }

            return stoppingFloors.ToArray();
        }

        private void GoDown(int[][] queues, int capacity)
        {
            for (int floor = queues.Length - 1; floor >= 0; floor--)
            {
                for (int destionationPosition = 0; destionationPosition < queues[floor].Length; destionationPosition++)
                {
                    if (queues[floor][destionationPosition] < floor)
                    {
                        if ((LiftQuee.Count) < capacity)
                        {
                            EnqueePassengerIfPossible(queues, floor, destionationPosition);
                        }
                    }
                    if (queues[floor][destionationPosition] == floor)
                    {
                        passengerTransported++;
                    }
                }
                DequeePassngerIfPossible(floor);
            }
        }

        private void GoUP(int[][] queues, int capacity)
        {
            for (int floor = 0; floor < queues.Length; floor++)
            {
                for (int destionationPosition = 0; destionationPosition < queues[floor].Length; destionationPosition++)
                {
                    //Iteration Cycle needed otherweise lift won´t transport someone up in the next iteration after it transported someone down befoe:
                    //quee strcture [-1, 6]
                    if (queues[floor][destionationPosition] > floor ||
                        (queues[floor].Count() - 1 >= iterationCycle && queues[floor][iterationCycle] > floor))
                    {
                        if ((LiftQuee.Count) < capacity)
                        {
                            EnqueePassengerIfPossible(queues, floor, destionationPosition);
                        }
                    }
                    else if (queues[floor][destionationPosition] == floor)
                    {
                        passengerTransported++;
                    }
                    else
                    {
                        break;
                    }

                }
                DequeePassngerIfPossible(floor);
            }
        }

        private void EnqueePassengerIfPossible(int[][] queues, int floor, int destionationPosition)
        {
            if (queues[floor][destionationPosition] != -1)
            {
                LiftQuee.Enqueue(queues[floor][destionationPosition]);
                passengerTransported++;
                if (stoppingFloors.Last() != floor)
                {
                    stoppingFloors.Add(floor);
                }
                //Passagier wurde schon transportiert
                queues[floor][destionationPosition] = -1;
            }
        }

        private void SumUpTotalPassengers(int[][] queues)
        {
            foreach (int[] passengers in queues)
            {
                foreach (int pass in passengers)
                {
                    if (pass >= 0)
                    {
                        TotalPessengersCount++;
                    }
                }
            }
        }

        private void DequeePassngerIfPossible(int floor)
        {
            if (LiftQuee.Count > 0 && LiftQuee.Peek() == floor)
            {
                if (stoppingFloors.Last() != floor)
                {
                    stoppingFloors.Add(floor);
                }
                List<int> tempQuee = LiftQuee.ToList();
                foreach (int passenger in tempQuee)
                {
                    if (LiftQuee.Peek() == floor)
                    {
                        LiftQuee.Dequeue();
                    }
                }
            }
        }
    }
}
