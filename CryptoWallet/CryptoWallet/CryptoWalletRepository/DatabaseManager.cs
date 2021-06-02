using CryptoWalletDB;

namespace CryptoWalletRepository
{
    public class DatabaseManager
    {
        private static readonly CryptoWalletContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new CryptoWalletContext();
        }

        // Provide an accessor to the database
        public static CryptoWalletContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
