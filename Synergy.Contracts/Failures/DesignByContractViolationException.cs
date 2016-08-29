using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Synergy.Contracts
{
    /// <summary>
    /// Wyj�tek rzucany g��wnie przez klas� <see cref="Fail"/>. M�wi on o tym, �e �wiat zewn�trzny
    /// dla naszej logiki nie spe�ni� kontraktu jaki nasz kod zak�ada� - np. przyszed� null do metody
    /// a my nie zak�adali�my, �e mo�e przyj��. Nasz kod zak�ada�, �e jest uruchomiony na serwerze a 
    /// okaza�o si� inaczej, itd. <br/>
    /// 
    /// Ten exception nigdy nie powinien by� rzucany. Je�li go widzisz 
    /// oznacza to, �e jest co� nie tak ze �wiatem zewn�trznym, kt�ry nie spe�nia kontraktu danej metody.
    /// </summary>
    [Serializable]
    public class DesignByContractViolationException : Exception
    {
        /// <summary>
        /// Wyj�tek rzucany g��wnie przez klas� <see cref="Fail"/>. M�wi on o tym, �e �wiat zewn�trzny
        /// dla naszej logiki nie spe�ni� kontraktu jaki nasz kod zak�ada� - np. przyszed� null do metody
        /// a my nie zak�adali�my, �e mo�e przyj��. Nasz kod zak�ada�, �e jest uruchomiony na serwerze a 
        /// okaza�o si� inaczej, itd. <br/>
        /// 
        /// Ten exception nigdy nie powinien by� rzucany. Je�li go widzisz 
        /// oznacza to, �e jest co� nie tak ze �wiatem zewn�trznym, kt�ry nie spe�nia kontraktu danej metody.
        /// </summary>
        public DesignByContractViolationException()
        {
        }

        /// <summary>
        /// Wyj�tek rzucany g��wnie przez klas� <see cref="Fail"/>. M�wi on o tym, �e �wiat zewn�trzny
        /// dla naszej logiki nie spe�ni� kontraktu jaki nasz kod zak�ada� - np. przyszed� null do metody
        /// a my nie zak�adali�my, �e mo�e przyj��. Nasz kod zak�ada�, �e jest uruchomiony na serwerze a 
        /// okaza�o si� inaczej, itd. <br/>
        /// 
        /// Ten exception nigdy nie powinien by� rzucany. Je�li go widzisz 
        /// oznacza to, �e jest co� nie tak ze �wiatem zewn�trznym, kt�ry nie spe�nia kontraktu danej metody.
        /// </summary>
        public DesignByContractViolationException([NotNull] string message) : base(message)
        {
        }

        /// <summary>
        /// Konstruktor s�u��cy do deserializacji. Bez niego ten wyj�tek nie jest w stanie sie zdeserializowa�.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DesignByContractViolationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}