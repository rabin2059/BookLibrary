import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import { ChevronDown, CircleUserRound, Heart } from "lucide-react";
import images from "../../assets/assets";

const NavBar = () => {
  const [categoryDropdownOpen, setCategoryDropdownOpen] = useState(false);

  return (
    <div className="w-full">
      {/* Top promotion bar */}
      <div className="w-full bg-web-secondary text-web-primary py-4 text-center">
        <div className="container bg-web-secondary mx-auto flex items-center justify-center">
          <span className="text-md text-white bg-web-secondary">
            Get a 80% off on Purchase Rs 2000
          </span>
          <NavLink
            to="/shop"
            className="text-web-primary bg-web-secondary font-bold hover:text-yellow-200 ml-1 inline-flex items-center underline"
          >
            Shop Now
            <img
              className="w-[16px] bg-web-secondary ml-3"
              src={images.arrow}
              alt=""
            />
          </NavLink>
        </div>
      </div>

      {/* Main Navigation */}
      <div className="container mx-auto py-4 px-4 md:px-0">
        <div className="flex items-center justify-between">
          {/* Logo */}
          <div className="flex items-center">
            <div className="text-2xl font-extrabold flex items-center text-gray-700">
              <img className="h-[40px]" src={images.logo} alt="" />
              Booklett
            </div>
          </div>

          {/* Navigation Links */}
          <div className="hidden md:flex items-center space-x-6">
            <NavLink
              to="/"
              className={({ isActive }) =>
                `flex items-center py-2 px-3 text-l font-bold transition-colors ${
                  isActive
                    ? "bg-gray-700 text-web-primary rounded-full px-5"
                    : "text-gray-700 hover:text-gray-900"
                }`
              }
            >
              Home
            </NavLink>

            <div className="relative">
              <button
                className="flex text-l font-bold items-center py-2 text-gray-700 hover:text-gray-900"
                onClick={() => setCategoryDropdownOpen(!categoryDropdownOpen)}
              >
                Category
                <ChevronDown className="w-4 h-4 ml-1" />
              </button>
              {categoryDropdownOpen && (
                <div className="absolute mt-2 w-48 bg-white rounded-md shadow-lg py-1 z-10">
                  <NavLink
                    to="/category/fiction"
                    className={({ isActive }) =>
                      `block px-4 py-2 text-l font-bold transition-colors ${
                        isActive
                          ? "bg-gray-700 text-web-primary rounded-full px-5"
                          : "text-gray-700 hover:bg-gray-100"
                      }`
                    }
                  >
                    Fiction
                  </NavLink>
                  <NavLink
                    to="/category/non-fiction"
                    className={({ isActive }) =>
                      `block px-4 py-2 text-l font-bold transition-colors ${
                        isActive
                          ? "bg-gray-700 text-web-primary rounded-full px-5"
                          : "text-gray-700 hover:bg-gray-100"
                      }`
                    }
                  >
                    Non-Fiction
                  </NavLink>
                  <NavLink
                    to="/category/children"
                    className={({ isActive }) =>
                      `block px-4 py-2 text-l font-bold transition-colors ${
                        isActive
                          ? "bg-gray-700 text-web-primary rounded-full px-5"
                          : "text-gray-700 hover:bg-gray-100"
                      }`
                    }
                  >
                    Children's Books
                  </NavLink>
                  <NavLink
                    to="/category/academic"
                    className={({ isActive }) =>
                      `block px-4 py-2 text-l font-bold transition-colors ${
                        isActive
                          ? "bg-gray-700 text-web-primary rounded-full px-5"
                          : "text-gray-700 hover:bg-gray-100"
                      }`
                    }
                  >
                    Academic
                  </NavLink>
                </div>
              )}
            </div>

            <NavLink
              to="/new-arrivals"
              className={({ isActive }) =>
                `py-2 px-3 text-l font-bold transition-colors ${
                  isActive
                    ? "bg-gray-700 text-web-primary rounded-full px-5"
                    : "text-gray-700 hover:text-gray-900"
                }`
              }
            >
              New Arrivals
            </NavLink>
            <NavLink
              to="/best-selling"
              className={({ isActive }) =>
                `py-2 px-3 text-l font-bold transition-colors ${
                  isActive
                    ? "bg-gray-700 text-web-primary rounded-full px-5"
                    : "text-gray-700 hover:text-gray-900"
                }`
              }
            >
              Best Selling Books
            </NavLink>
            <NavLink
              to="/deal-of-the-day"
              className={({ isActive }) =>
                `py-2 px-3 text-l font-bold transition-colors ${
                  isActive
                    ? "bg-gray-700 text-web-primary rounded-full px-5"
                    : "text-gray-700 hover:text-gray-900"
                }`
              }
            >
              Deal of The Day
            </NavLink>
            <NavLink
              to="/contact"
              className={({ isActive }) =>
                `py-2 px-3 text-l font-bold transition-colors ${
                  isActive
                    ? "bg-gray-700 text-web-primary rounded-full px-5"
                    : "text-gray-700 hover:text-gray-900"
                }`
              }
            >
              Contact Us
            </NavLink>
          </div>

          {/* Right side icons */}
          <div className="flex items-center space-x-4">
            <NavLink
              to="/cart"
              className="relative p-2 bg-web-secondary rounded-full"
            >
              <img
                className="h-[34px] bg-transparent"
                src={images.shoppingBag}
                alt=""
              />
              <span className="absolute bottom-2 right-2 bg-orange-500 text-white text-[9px] font-bold w-3.5 h-3.5 flex items-center justify-center rounded-full">
                10
              </span>
            </NavLink>
            <NavLink
              to="/wishlist"
              className="p-2 rounded-full border border-gray-400"
            >
              <Heart className="bg-transparent h-[32px] w-[32px]"/>
            </NavLink>
            <NavLink
              to="/signin"
              className="bg-web-primary text-l font-bold text-gray-700 py-2 border border-gray-800 px-4 rounded-full px-5 flex items-center space-x-1 transition-colors"
            >
              <span className="bg-transparent h-[24px]">Sign In</span>

              <CircleUserRound className="bg-transparent" />
            </NavLink>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NavBar;
