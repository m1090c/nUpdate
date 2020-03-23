﻿using System.Threading.Tasks;
using nUpdate.Administration.PluginBase.ViewModels;

namespace nUpdate.Administration.ViewModels.NewProject
{
    public class GenerateKeyPairPageViewModel : WizardPageViewModelBase
    {
        private readonly NewProjectBase _newProjectBase;

        public GenerateKeyPairPageViewModel(NewProjectBase @base)
        {
            _newProjectBase = @base;
            NeedsUserInteraction = false;
        }

        public override async void OnNavigated(WizardPageViewModelBase fromPage, WizardViewModelBase window)
        {
            base.OnNavigated(fromPage, window);

            // Generate the key pair.
            await GenerateKeyPair();
            
            CanGoForward = true;
            CanBeShown = false;

            // Request going forward to the next page automatically.
            _newProjectBase.RequestGoForward();
        }

        private Task GenerateKeyPair()
        {
            return Task.Run(() =>
            {
                var rsa = new RsaManager();
                _newProjectBase.ProjectCreationData.Project.PublicKey = rsa.PublicKey;
                _newProjectBase.ProjectCreationData.PrivateKey = rsa.PrivateKey;
            });
        }
    }
}