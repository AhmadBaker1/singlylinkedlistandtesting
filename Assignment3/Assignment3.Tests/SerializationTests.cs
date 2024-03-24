using Assignment3.Utility;
using NUnit.Framework;
using System.IO;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private SLL<User> users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Initialize the users object
            this.users = new SLL<User>();

            // Add users to the list
            users.Append(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
            if (File.Exists(testFileName))
            {
                File.Delete(testFileName);
            }
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.Serialize(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));

            // Verify the content of the file
            SLL<User> deserializedUsers = SerializationHelper.Deserialize<User>(testFileName);
            Assert.AreEqual(users.GetSize(), deserializedUsers.GetSize());
            for (int i = 0; i < users.GetSize(); i++)
            {
                User expected = users.GetAtIndex(i);
                User actual = deserializedUsers.GetAtIndex(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.Serialize(users, testFileName);
            SLL<User> deserializedUsers = SerializationHelper.Deserialize<User>(testFileName);

            Assert.AreEqual(users.GetSize(), deserializedUsers.GetSize());

            for (int i = 0; i < users.GetSize(); i++)
            {
                User expected = users.GetAtIndex(i);
                User actual = deserializedUsers.GetAtIndex(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }
    }
}