﻿namespace System.Linq.Expressions
{
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    internal class DynamicExpression2 : DynamicExpression, IArgumentProvider
    {
        private object _arg0;
        private readonly Expression _arg1;

        internal DynamicExpression2(Type delegateType, CallSiteBinder binder, Expression arg0, Expression arg1) : base(delegateType, binder)
        {
            this._arg0 = arg0;
            this._arg1 = arg1;
        }

        internal override ReadOnlyCollection<Expression> GetOrMakeArguments()
        {
            return Expression.ReturnReadOnly(this, ref this._arg0);
        }

        internal override DynamicExpression Rewrite(Expression[] args)
        {
            return Expression.MakeDynamic(base.DelegateType, base.Binder, args[0], args[1]);
        }

        Expression IArgumentProvider.GetArgument(int index)
        {
            switch (index)
            {
                case 0:
                    return Expression.ReturnObject<Expression>(this._arg0);

                case 1:
                    return this._arg1;
            }
            throw new InvalidOperationException();
        }

        int IArgumentProvider.ArgumentCount
        {
            get
            {
                return 2;
            }
        }
    }
}

