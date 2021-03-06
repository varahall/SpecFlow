﻿using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;
using TechTalk.SpecFlow.UnitTestProvider;
using TechTalk.SpecFlow.xUnit.SpecFlowPlugin;


[assembly: RuntimePlugin(typeof(RuntimePlugin))]


namespace TechTalk.SpecFlow.xUnit.SpecFlowPlugin
{
    public class RuntimePlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters, UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            runtimePluginEvents.CustomizeScenarioDependencies += RuntimePluginEvents_CustomizeScenarioDependencies;
            unitTestProviderConfiguration.UseUnitTestProvider("xunit");
        }

        private void RuntimePluginEvents_CustomizeScenarioDependencies(object sender, CustomizeScenarioDependenciesEventArgs e)
        {
            var container = e.ObjectContainer;

            container.RegisterTypeAs<OutputHelper, ISpecFlowOutputHelper>();
            container.RegisterTypeAs<XUnitTraceListener, ITraceListener>();
        }
    }
}
