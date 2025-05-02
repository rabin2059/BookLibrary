import React, { useContext } from "react";
import { AppContext } from "../../context/AppContext";
import { LogOut } from "lucide-react";
import { NavLink } from "react-router-dom";
import images from "../../assets/assets";

const AdminSidebar = () => {
  const menuItems = [
    { name: "Dashboard", path: "/admin", icons: images.logo},
    { name: "Requests", path: "/admin/request", icons: images.arrow},
  ];

  return (
    <div className="md:w-64 w-16 border-r min-h-screen text-base border-gray-500 py-2 flex flex-col">
      {menuItems.map((item) => (
        <NavLink
          to={item.path}
          key={item.name}
          end={item.path == "/admin"}
          className={({ isActive }) =>
            `flex items-center md:flex-row flex-col md:justify-start justify-center py-3.5 md:px-10 gap-3 ${
              isActive
                ? "bg-indigo-50 border-r-[6px] border-indigo-500/90"
                : "hover:bg-gray-100/90 border-r-[6px] border-white hover:border-gray-100/90"
            }`
          }
        >
          <img src={item.icons} alt="" className="w-6 h-6" />
          <p className="md:block hidden text-center">{item.name}</p>
        </NavLink>
      ))}
      <button
        onClick={() => {
          localStorage.removeItem("token");
          localStorage.removeItem("role");
          window.location.href = "/";
        }}
        className="flex items-center md:flex-row flex-col md:justify-start justify-center py-3.5 md:px-10 gap-3 hover:bg-red-100 border-r-[6px] border-white hover:border-red-300 mt-auto"
      >
       <LogOut />
        <p className="md:block hidden text-center text-red-600">Logout</p>
      </button>
    </div>
  );
};

export default AdminSidebar;
