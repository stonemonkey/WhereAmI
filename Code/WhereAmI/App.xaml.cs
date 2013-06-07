using System.Collections.Generic;
using Caliburn.Micro;
using System;
using WhereAmI.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WhereAmI.Common;
using Windows.ApplicationModel.Activation;
using WhereAmI.Search;

namespace WhereAmI
{
    sealed partial class App
    {
        private WinRTContainer _container;
        //private FirstFloor.XamlSpy.XamlSpyService service;

        public App()
        {
            this.InitializeComponent();
            //this.service = new FirstFloor.XamlSpy.XamlSpyService(this);
        }

        protected override void Configure()
        {
            base.Configure();

            _container = new WinRTContainer(RootFrame);
            _container.RegisterWinRTServices();
            _container.RegisterSingleton(typeof(IUiService), null, typeof(UiService));
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override Type GetDefaultView()
        {
            return typeof(ShellView);
        }

        /// <summary>
        /// Invoked when the application is activated to display search results.
        /// </summary>
        /// <param name="args">Details about the activation request.</param>
        protected async override void OnSearchActivated(SearchActivatedEventArgs args)
        {
            // TODO: Register the Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().QuerySubmitted
            // event in OnWindowCreated to speed up searches once the application is already running

            // If the Window isn't already using Frame navigation, insert our own Frame
            var previousContent = Window.Current.Content;
            var frame = previousContent as Frame;

            // If the app does not contain a top-level frame, it is possible that this 
            // is the initial launch of the app. Typically this method and OnLaunched 
            // in App.xaml.cs can call a common method.
            if (frame == null)
            {
                // Create a Frame to act as the navigation context and associate it with
                // a SuspensionManager key
                frame = new Frame();
                SuspensionManager.RegisterFrame(frame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }
            }

            frame.Navigate(typeof(SearchResultsPage), args.QueryText);
            Window.Current.Content = frame;

            // Ensure the current window is active
            Window.Current.Activate();
        }

        //protected override void OnWindowCreated(WindowCreatedEventArgs args)
        //{
        //    base.OnWindowCreated(args);
        //    this.service.StartService();
        //}

    }
}
