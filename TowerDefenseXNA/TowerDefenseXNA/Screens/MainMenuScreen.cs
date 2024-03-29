#region File Description
//-----------------------------------------------------------------------------
// MainMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
#endregion

namespace GameStateManagement
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        #region Initialization
        ContentManager Content;
        GameComponentCollection Components;
        Game game;
        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen(ContentManager Content, GameComponentCollection Components, Game game)
            : base("Tower Defense")
        {
            this.Content = Content;
            this.Components = Components;
            this.game = game;
            // Create our menu entries.
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game solo");
            MenuEntry multiMenuEntry = new MenuEntry("Multiplayer");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry creditMenuEntry = new MenuEntry("Credit");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");
            

            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            multiMenuEntry.Selected += MultiMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            creditMenuEntry.Selected += CreditMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(multiMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(creditMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }

        public MainMenuScreen(ContentManager Content)
            : base("Tower Defense")
        {
            this.Content = Content;
            // Create our menu entries.
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game solo");
            MenuEntry multiMenuEntry = new MenuEntry("Multiplayer");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry creditMenuEntry = new MenuEntry("Credit");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");


            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            multiMenuEntry.Selected += MultiMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            creditMenuEntry.Selected += CreditMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(multiMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(creditMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }

        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            /*LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());*/
            ScreenManager.AddScreen(new SelectLevelMenuScreen(Content), e.PlayerIndex);
        }

        void MultiMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new MultiPlayerMenuScreen(Content, Components, game), e.PlayerIndex);
        }

        void CreditMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new CreditMenuScreen(), e.PlayerIndex);
        }



        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }



        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Are you sure you want to exit the game?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to exit" message box.
        /// </summary>
        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        #endregion
    }
}
