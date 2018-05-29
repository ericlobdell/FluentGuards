using System;

namespace FluentGuards
{
    public static class Guards
    {
        private static GuardInvoker invoker = new GuardInvoker();

        public static GuardInvoker Require(object o, string msg) =>
          invoker.Require(o, msg);

        public static GuardInvoker Require(params (object value, string errorMessage)[] args) =>
          invoker.Require(args);

        public static GuardInvoker ThrowIf(bool condition, string msg) =>
          invoker.ThrowIf(condition, msg);

        public static GuardInvoker ThrowIf(params (bool condition, string errorMessage)[] args) =>
          invoker.ThrowIf(args);

    }
}
