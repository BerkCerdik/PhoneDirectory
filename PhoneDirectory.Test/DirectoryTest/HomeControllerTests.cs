using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Directory.Controllers;
using Directory.Model.ViewModels;
using Directory.Model.ORM.Context;
using NUnit.Framework;

namespace PhoneDirectory.Test.DirectoryTest
{
    class HomeControllerTests
    {
        [Test]
        public void IndexTest()
        {
            DirectoryContext _directorycontext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            HomeController homeController = new HomeController(_directorycontext, _config);
            var result = homeController.Index();

            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result);
        }


        [Test]
        public void PeopleTest()
        {
            DirectoryContext _directorycontext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            HomeController homeController = new HomeController(_directorycontext, _config);

            var result = homeController.People();

            Assert.IsNotNull(result);

         }

        [Test]
        public void PeopleListDetailTest()
        {
            DirectoryContext _directorycontext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            HomeController homeController = new HomeController(_directorycontext, _config);

            var result = homeController.PeopleListDetail(5);

            Assert.IsNotNull(result);

        }

        [Test]
        public void PeopleAddTest()
        {
            DirectoryContext _directorycontext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            HomeController homeController = new HomeController(_directorycontext, _config);

            PersonVM personModel = new PersonVM();

            var result = homeController.PeopleAdd(personModel);

            Assert.IsNotNull(result);
            Assert.IsNotNull(personModel.Name, personModel.Surname, personModel.Company);

        }

        [Test]
        public void PeaopleDeleteTest()
        {
            DirectoryContext _directorycontext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            HomeController homeController = new HomeController(_directorycontext, _config);

            PersonDeleteVM personModel = new PersonDeleteVM();

            var result = homeController.PeaopleDelete(personModel);

            Assert.IsNotNull(result);
            Assert.IsNotNull(personModel);

        }

        [Test]
        public void ContactAddTest()
        {
            DirectoryContext _directorycontext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            HomeController homeController = new HomeController(_directorycontext, _config);

            ContactInfoVM contactModel = new ContactInfoVM();

            var result = homeController.ContactAdd(contactModel);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ContactDeleteTest()
        {
            DirectoryContext _directorycontext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            HomeController homeController = new HomeController(_directorycontext, _config);

            ContactDeleteVM contactModel = new ContactDeleteVM();

            var result = homeController.ContactDelete(contactModel);

            Assert.IsNotNull(result);
            Assert.IsNotNull(contactModel);

        }


    }
}
