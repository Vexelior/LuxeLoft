import Preloader from "../Preloader/Preloader";
import React, { useEffect } from "react";

function HomeLayout({ children }: { children: React.ReactNode }) {

  function hidePreloader() {
    const preloader = document.querySelector(".preloader");
    if (preloader) {
        preloader.classList.add("hidden");
    }
  }
  
  useEffect(() => {
    hidePreloader();
  }, []);


  return (
    <>
      <Preloader />
      <main>
          {children}
      </main>
    </>
  );
}
export default HomeLayout;