# BankDatabaseGUI.

BankDatabaseGUI is a desktop application built with C# and WPF (Windows Presentation Foundation) that provides a graphical user interface for managing a banking database system. It allows users to perform various banking operations such as creating accounts, managing cards, and processing financial transactions.
🚀 Features

The application is structured around several key modules:
👤 Account Management

    Create Account: Register new bank accounts (CreateAccountWindow).

    Update Account: Modify existing account details (UpdateAccountWindow).

    Delete Account: Remove accounts from the system (DeleteAccountWindow).

    View Accounts: Search and select specific accounts (SelectAccountWindow).

💳 Card Management

    Add Card: Issue new cards linked to accounts (AddCardWindow).

    Update Card: Update card information (UpdateCardWindow).

    Delete Card: Deactivate or remove cards (DeleteCardWindow).

    View Cards: specific card details (SelectCardWindow).

💸 Financial Operations

    Transactions: Perform deposits or withdrawals (MakeTransactionWindow).

    Transfers: Transfer funds between accounts (MakeTransferWindow).

    History: View transaction and transfer history (SelectTransactionsWindow, SelectTransfersWindow).

🛠 General Database Operations

    Centralized windows for Insertion, Deletion, Selection, and Updates (InsertWindow, DeleteWindow, SelectWindow, UpdateWindow).

💻 Technologies Used

    Language: C#

    Framework: .NET / WPF (Windows Presentation Foundation)

    IDE: Microsoft Visual Studio

🛠️ Installation & Setup

Follow these steps to set up and run the project locally:

    Clone the Repository

    Open the Project

        Navigate to the cloned directory.

        Open the solution file BankDatabaseGUI.sln in Microsoft Visual Studio.

    Restore Dependencies

        Visual Studio should automatically restore the necessary NuGet packages. If not, right-click the solution in the Solution Explorer and select Restore NuGet Packages.

    Build and Run

        Press F5 or click the Start button in Visual Studio to build and compile the application.

📸 Usage

Upon launching the application (MainWindow.xaml), you will likely be presented with a dashboard or menu to navigate between the different modules (Accounts, Cards, Transactions).

    Use the Insert/Add menus to input new data into the system.

    Use the Select/View menus to query the database.

    Use the Update or Delete options to manage existing records.

🤝 Contributors

    - Mohamed Hisham

    - Kareem Mohamed Fathy

    -Felopater Ashraf Rushdy
