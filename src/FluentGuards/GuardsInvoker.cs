using System;

namespace FluentGuards
{
    public class GuardInvoker
    {
        public GuardInvoker Require(object o, string msg)
        {
            if ( o is string s && string.IsNullOrWhiteSpace(s) )
                throw new ArgumentException(msg);

            if ( o == null )
                throw new ArgumentException(msg);

            return this;
        }

        public GuardInvoker Require(params (object value, string errorMessage)[] args)
        {
            foreach ( var a in args )
                Require(a.value, a.errorMessage);

            return this;
        }

        public GuardInvoker ThrowIf(bool condition, string msg)
        {
            if ( condition )
                throw new ArgumentException(msg);

            return this;
        }

        public GuardInvoker ThrowIf(params (bool condition, string errorMessage)[] args)
        {
            foreach ( var a in args )
                ThrowIf(a.condition, a.errorMessage);

            return this;
        }
    }
}
