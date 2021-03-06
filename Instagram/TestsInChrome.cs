﻿using System;
using System.Collections.Generic;
using Instagram.Extensions;
using Instagram.Pages;
using Ninject;
using NUnit.Framework;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Instagram
{
    [TestFixture]
    public class TestsInChrome : SetUp
    {
        private static readonly Uri URL = new Uri(ConfigurationManager.AppSettings["InstagramUri"]);

        private List<string> credsList = File.ReadLines(ConfigurationManager.AppSettings["Credentials"]).ToList();

        private List<string> hashtags = File.ReadAllLines(ConfigurationManager.AppSettings["Hashtags"]).ToList();
        private string userName;
        private string password;

        [SetUp]
        public void SetUp()
        {
            Inj.Driver = Inj.kernel.Get<IBrowsers>().GetChromeDriver();
            userName = credsList[0];
            password = credsList[1];
        }

        [TearDown]
        public void TearDown()
        {
            Inj.Driver.Manage().Cookies.DeleteAllCookies();
            Inj.Driver.CLearBrowserLocalStorage();
        }

        [Test]
        [TestCase(7)]
        [Description("Make Likes")]
        public void LetsPutSomeLikes(int numberOfPosts)
        {
            InstPages.InstagramSignUpP.Open(URL);
            InstagramMainFeedPage feedPage = InstPages.InstagramSignUpP.OpenLogin()
                 .LoginToInstagram(userName, password);
            InstagramSearchResultsPage page;
            PostDetails postdet;

            foreach (string tag in hashtags)
            {
                postdet = feedPage
                    .OpenResultsForAHashTag(tag)
                    .OpenFirstPostDetails();

                PutLikesAndFollowing(numberOfPosts, postdet);
            }
        }

        //[Test]
        //[TestCase(100)]
        [Description("Unfollow people")]
        public void Unfollow()
        {
            InstPages.InstagramSignUpP.Open(URL);
            InstagramMainFeedPage feedPage = InstPages.InstagramSignUpP.OpenLogin()
                 .LoginToInstagram(userName, password);
        }

        private static void PutLikes(int numberOfPosts, PostDetails postdet)
        {
            if (postdet.PutLikesOnPostDetails(numberOfPosts, false))
            {
                try
                {
                    postdet.ClosePostDetailsPage();
                }
                catch (Exception)
                {
                    Console.WriteLine("Close details");
                }
            }
        }

        private static void PutLikesAndFollowing(int numberOfPosts, PostDetails postdet)
        {
            if (postdet.PutLikesOnPostDetails(numberOfPosts, true))
            {
                try
                {
                    postdet.ClosePostDetailsPage();
                }
                catch (Exception)
                {
                    Console.WriteLine("Close details");
                }
            }
        }
    }
}