﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TDD_HomeWork2_BookStore
{
    [TestClass]
    public class ShoppingDiscount
    {
        public Dictionary<int, decimal> discountSetting = new Dictionary<int, decimal>()
        {
            { 1, 1m },
            { 2, 0.95m },
            { 3, 0.9m },
            { 4, 0.8m },
            { 5, 0.75m },
            { 0, 0m },
        };

        [TestMethod]
        public void Cart_Add_Potter1_has_1_Should_Be_100()
        {
            // arrange
            List<Book> bookList = new List<Book>()
            {
                new Book {episode = 1, quantity = 1, price = 100 },
            };

            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 100m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Cart_Add_Potter1_has_1_Potter2_has_1_Should_Be_190()
        {
            // arrange
            List<Book> bookList = new List<Book>
            {
                new Book { episode = 1, quantity=1, price = 100},
                new Book { episode = 2, quantity=1, price = 100}
            };
            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 190m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Cart_Add_Potter1_has_1_Potter2_has_1_Potter3_has_1_Should_Be_270()
        {
            // arrange
            List<Book> bookList = new List<Book>
            {
                new Book { episode = 1, quantity=1, price = 100},
                new Book { episode = 2, quantity=1, price = 100},
                new Book { episode = 3, quantity=1, price = 100},
            };
            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 270m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Cart_Add_Potter1_has_1_Potter2_has_1_Potter3_has_1_Potter4_has_1_Should_Be_320()
        {
            // arrange
            List<Book> bookList = new List<Book>
            {
                new Book { episode = 1, quantity=1, price = 100},
                new Book { episode = 2, quantity=1, price = 100},
                new Book { episode = 3, quantity=1, price = 100},
                new Book { episode = 4, quantity=1, price = 100},
            };
            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 320m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Cart_Add_Potter1_has_1_Potter2_has_1_Potter3_has_1_Potter4_has_1_Potter5_has_1_Should_Be_375()
        {
            // arrange
            List<Book> bookList = new List<Book>
            {
                new Book { episode = 1, quantity=1, price = 100},
                new Book { episode = 2, quantity=1, price = 100},
                new Book { episode = 3, quantity=1, price = 100},
                new Book { episode = 4, quantity=1, price = 100},
                new Book { episode = 5, quantity=1, price = 100},
            };
            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 375m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Cart_Add_Potter1_has_1_Potter2_has_1_Potter3_has_2_Should_Be_370()
        {
            // arrange
            List<Book> bookList = new List<Book>
            {
                new Book { episode = 1, quantity=1, price = 100},
                new Book { episode = 2, quantity=1, price = 100},
                new Book { episode = 3, quantity=2, price = 100},
            };
            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 370m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Cart_Add_Potter1_has_1_Potter2_has_2_Potter3_has_2_Should_Be_460()
        {
            // arrange
            List<Book> bookList = new List<Book>
            {
                new Book { episode = 1, quantity=1, price = 100},
                new Book { episode = 2, quantity=2, price = 100},
                new Book { episode = 3, quantity=2, price = 100},
            };
            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 460m;

            Assert.AreEqual(excepted, actual);
        }


        [TestMethod]
        public void Cart_Add_NoBook_Should_Be_0()
        {
            // arrange
            List<Book> bookList = new List<Book>
            {
            };
            // act
            decimal actual = this.CalculatePrice(bookList);
            // assert
            var excepted = 0m;

            Assert.AreEqual(excepted, actual);
        }

        private decimal CalculatePrice(List<Book> bookList)
        {
            var bookTypeCount = bookList.Count();
            decimal totalPrice = default(decimal);

            while (bookList.Any(b => b.quantity > 0))
            {
                var tempPrice = default(decimal);
                foreach (var book in bookList)
                {
                    if (book.quantity == 0)
                    {
                        bookTypeCount--;
                        continue;
                    }
                    tempPrice += book.price;
                    book.quantity--;
                }
                totalPrice += tempPrice * discountSetting[bookTypeCount];
            }
            return totalPrice;
        }
    }
}
