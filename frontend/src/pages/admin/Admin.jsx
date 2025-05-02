import { Outlet } from "react-router-dom";
import Sidebar from "../../components/admin/AdminSideBar";

const Admin = () => {
  return (
    <div className="text-default min-h-screen bg-white">
      {/* <Navbar /> */}
      <div className="flex">
        {" "}
        <Sidebar />
        <div className="flex-1">{<Outlet />}</div>
      </div>
    </div>
  );
};

export default Admin;
