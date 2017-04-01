using System.Collections.Generic;

namespace SpamFilterAutomata
{
    public abstract class BaseState : IState
    {

        public List<IState> NextStates { get; protected set; }
        public StateMachine Automata { get; protected set; }

        public virtual bool MoveToNextState { get; protected set; }

        protected BaseState(StateMachine stateMachine)
        {
            this.Automata = stateMachine;
            NextStates = new List<IState>();

        }

        public virtual Status ReadNext(char character)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Reset()
        {
            throw new System.NotImplementedException();
        }

        

        public virtual IState OnComplete()
        {
            if (MoveToNextState)
            {
                //do logic
                return null;

            }
            return null;
        }

        
    }
}
