﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TDD_HomeWork2_BookStore
{
    [TestClass]
    public class ShoppingDiscount
    {
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
                        continue;
                    }
                    tempPrice += book.price;
                    book.quantity--;
                }
                totalPrice += tempPrice * GetDiscountSetting(bookTypeCount);
            }
            return totalPrice;
        }

        private decimal GetDiscountSetting(int bookTypeCount)
        {
            switch (bookTypeCount)
            {
                case 1:
                    return 1m;
                case 2:
                    return 0.95m;
                case 3:
                    return 0.9m;
                case 4:
                    return 0.8m;
                case 5:
                    return 0.75m;
                default:
                    return 0m;
            }
        }
    }
}
