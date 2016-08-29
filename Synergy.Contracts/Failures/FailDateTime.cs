﻿using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Synergy.Contracts
{
    public static partial class Fail
    {
        /// <summary>
        /// Throws exception when the checked DateTime contains more than just a date - when it contains hours, minutes or seconds fraction.
        /// <para>REMARKS: You can pass the <see langword="null" /> and it will not fail as there is nothing to check against being a midnight time.</para>
        /// </summary>
        /// <param name="value">Nullable DateTime to check.</param>
        /// <param name="message">Message that will be passed to <see cref="DesignByContractViolationException"/> when the check fails.</param>
        /// <param name="args">Arguments that will be passed to <see cref="DesignByContractViolationException"/> when the check fails.</param>
        /// <example>
        /// <code>
        /// public List&lt;Contractor&gt; GetContractorsAged(DateTime minDate, DateTime? maxDate)
        /// {
        ///     Fail.IfNotMidnight(minDate, "minDate must be a midnight");
        ///     Fail.IfNotMidnight(maxDate, "maxDate must be a midnight");
        /// 
        ///     // WARN: Below is sample code with no sense at all
        ///     return new List&lt;Contractor&gt;(0);
        /// }
        /// </code>
        /// </example>
        [DebuggerStepThrough]
        [StringFormatMethod("message")]
        [AssertionMethod]
        public static void IfNotMidnight([CanBeNull] DateTime? value, [NotNull] string message, [NotNull] params object[] args)
        {
            Fail.RequiresMessage(message, args);

            if (value == null)
                return;

            DateTime dateTime = value.Value;
            Fail.IfNotEqual(dateTime.Date, dateTime, message, args);
        }
    }
}