﻿namespace System.Activities
{
    using System;
    using System.ComponentModel;

    internal static class VariableModifiersHelper
    {
        private static bool IsDefined(VariableModifiers modifiers)
        {
            if (modifiers != VariableModifiers.None)
            {
                return ((modifiers & (VariableModifiers.Mapped | VariableModifiers.ReadOnly)) == modifiers);
            }
            return true;
        }

        public static bool IsMappable(VariableModifiers modifiers)
        {
            return ((modifiers & VariableModifiers.Mapped) == VariableModifiers.Mapped);
        }

        public static bool IsReadOnly(VariableModifiers modifiers)
        {
            return ((modifiers & VariableModifiers.ReadOnly) == VariableModifiers.ReadOnly);
        }

        public static void Validate(VariableModifiers modifiers, string argumentName)
        {
            if (!IsDefined(modifiers))
            {
                throw FxTrace.Exception.AsError(new InvalidEnumArgumentException(argumentName, (int) modifiers, typeof(VariableModifiers)));
            }
        }
    }
}

