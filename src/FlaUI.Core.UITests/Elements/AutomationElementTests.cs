﻿using System;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    using FlaUI.Core.Definitions;

    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class AutomationElementTests : UITestBase
    {
        public AutomationElementTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void ParentTest()
        {
            RestartApp();
            var window = App.GetMainWindow(Automation);
            var child = window.FindFirstChild();
            Assert.That(child.Parent.ControlType, Is.EqualTo(ControlType.Window));
        }

        [Test]
        public void IsAvailableTest()
        {
            RestartApp();
            var window = App.GetMainWindow(Automation);
            Assert.That(window.IsAvailable, Is.True);
            window.Close();
            Retry.WhileTrue(() => window.IsAvailable, TimeSpan.FromSeconds(1));
            Assert.That(window.IsAvailable, Is.False);
        }
    }
}