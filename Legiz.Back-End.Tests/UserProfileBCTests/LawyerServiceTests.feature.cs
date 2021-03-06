// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Legiz.Back_End.Tests.UserProfileBCTests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class LawyerServiceTestsFeature : object, Xunit.IClassFixture<LawyerServiceTestsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "LawyerServiceTests.feature"
#line hidden
        
        public LawyerServiceTestsFeature(LawyerServiceTestsFeature.FixtureData fixtureData, Legiz_Back_End_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UserProfileBCTests", "LawyerServiceTests", "\tAs a Developer\r\n\tI want to add new Lawyer through API\r\n\tSo that It can be availa" +
                    "ble for applications", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
 #line hidden
#line 7
  testRunner.Given("the Endpoint https://localhost:5001/api/v1/lawyers is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add Lawyer")]
        [Xunit.TraitAttribute("FeatureTitle", "LawyerServiceTests")]
        [Xunit.TraitAttribute("Description", "Add Lawyer")]
        [Xunit.TraitAttribute("Category", "lawyer-adding")]
        [Xunit.TraitAttribute("Category", "mytag")]
        public virtual void AddLawyer()
        {
            string[] tagsOfScenario = new string[] {
                    "lawyer-adding",
                    "mytag"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Lawyer", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Username",
                            "Password",
                            "Email",
                            "LawyerName",
                            "LawyerLastName",
                            "District",
                            "Phone",
                            "University",
                            "Specialization",
                            "PriceLegalAdvice",
                            "PriceCustomContract"});
                table3.AddRow(new string[] {
                            "1",
                            "m123",
                            "s1",
                            "m@hotmail.com",
                            "Mauricio",
                            "Carmen",
                            "Callao",
                            "937598438",
                            "UPC",
                            "1",
                            "40",
                            "50"});
#line 12
 testRunner.When("A Post Request is sent", ((string)(null)), table3, "When ");
#line hidden
#line 15
 testRunner.Then("A Response with Status 200 is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Username",
                            "Password",
                            "Email",
                            "LawyerName",
                            "LawyerLastName",
                            "District",
                            "Phone",
                            "University",
                            "Specialization",
                            "PriceLegalAdvice",
                            "PriceCustomContract"});
                table4.AddRow(new string[] {
                            "1",
                            "m123",
                            "s1",
                            "m@hotmail.com",
                            "Mauricio",
                            "Carmen",
                            "Callao",
                            "937598438",
                            "UPC",
                            "BusinessLaw",
                            "40",
                            "50"});
#line 16
 testRunner.And("A Lawyer Resource is included in Response Body", ((string)(null)), table4, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                LawyerServiceTestsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                LawyerServiceTestsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
