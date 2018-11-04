using System;
using Xunit;

namespace FluentGuards.Test
{
    public class GuardsTests
    {
        [Fact]
        public void Require_throws_when_null()
        {
            Assert.Throws<ArgumentException>(() => Guards.Require(null, "message"));
        }

        [Fact]
        public void Require_throws_when_empty_string()
        {
            Assert.Throws<ArgumentException>(() => Guards.Require(string.Empty, "message"));
        }

        [Fact]
        public void Require_exception_uses_passed_message()
        {
            var errorMessage = "error";

            var ex = Assert.Throws<ArgumentException>(() => Guards.Require(string.Empty, errorMessage));

            Assert.Equal(errorMessage, ex.Message);
        }

        [Fact]
        public void Require_does_not_throws_when_non_empty_string()
        {
            Guards.Require("hello", "message");
        }

        [Fact]
        public void Require_accepts_tuples_as_args_list()
        {
            Guards.Require(
                ("hello", "message"),
                ("hey", "message"),
                ("hi", "message"));
        }

        [Fact]
        public void Require_does_not_throws_when_number_zero()
        {
            Guards.Require(0, "message");
        }

        [Fact]
        public void Require_returns_invoker_to_allow_chaining_more_guards()
        {
            var result = Guards.Require(0, "message");

            Assert.IsType<GuardInvoker>(result);
        }

        [Fact]
        public void ThrowIf_throws_when_conditioon_true()
        {
            Assert.Throws<ArgumentException>(() => Guards.ThrowIf(1 < 2, "message"));
        }

        [Fact]
        public void ThrowIf_exception_uses_passed_error_message()
        {
            var errorMessage = "error";

            var ex = Assert.Throws<ArgumentException>(() => Guards.ThrowIf(1 < 2, errorMessage));

            Assert.Equal(errorMessage, ex.Message);
        }

        [Fact]
        public void ThrowIf_does_not_throw_when_conditioon_false()
        {
            Guards.ThrowIf(1 > 2, "message");
        }

        [Fact]
        public void ThrowIf_accepts_tuples_as_args_list()
        {
            Guards.ThrowIf(
                (1 > 2, "message"),
                (false, "message"),
                (true == false, "message"));
        }

        [Fact]
        public void ThrowIf_returns_invoker_to_allow_chaining_more_guards()
        {
            var result = Guards.ThrowIf(6 == 9, "message");

            Assert.IsType<GuardInvoker>(result);
        }
    }
}
