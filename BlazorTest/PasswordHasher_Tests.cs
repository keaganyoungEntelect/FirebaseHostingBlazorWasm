using BlazorWasmSample.Services;
using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTest
{
    public class PasswordHasher_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task HashPassword_ValidInput_ReturnsHashedPassword()
        {
            
            var passwordHasher = new PasswordHasher();
            string password = "mySecurePassword";
            string salt = PasswordHasher.GenerateSalt();

            string hashedPassword = await passwordHasher.HashPassword(password, salt);

            Assert.IsNotNull(hashedPassword);
            Assert.AreNotEqual(password, hashedPassword);
        }

        [Test]
        public void GenerateSalt_ReturnsUniqueSalts()
        {
            
            var passwordHasher = new PasswordHasher();

            string salt1 = PasswordHasher.GenerateSalt();
            string salt2 = PasswordHasher.GenerateSalt();

            Assert.IsNotNull(salt1);
            Assert.IsNotNull(salt2);
            Assert.AreNotEqual(salt1, salt2);
        }

        [Test]
        public async Task HashPassword_SameInputAndSalt_ReturnsSameHash()
        {
            
            var passwordHasher = new PasswordHasher();
            string password = "mySecurePassword";
            string salt = PasswordHasher.GenerateSalt();

            string hashedPassword1 = await passwordHasher.HashPassword(password, salt);
            string hashedPassword2 = await passwordHasher.HashPassword(password, salt);

            Assert.AreEqual(hashedPassword1, hashedPassword2);
        }

        [Test]
        public async Task HashPassword_DifferentSalts_ReturnsDifferentHashes()
        {
            
            var passwordHasher = new PasswordHasher();
            string password = "mySecurePassword";
            string salt1 = PasswordHasher.GenerateSalt();
            string salt2 = PasswordHasher.GenerateSalt();

            string hashedPassword1 = await passwordHasher.HashPassword(password, salt1);
            string hashedPassword2 = await passwordHasher.HashPassword(password, salt2);

            Assert.AreNotEqual(hashedPassword1, hashedPassword2);
        }
    }
}
