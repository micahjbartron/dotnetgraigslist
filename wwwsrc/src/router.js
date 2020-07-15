import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./pages/Home.vue";
// @ts-ignore
import Dashboard from "./pages/Dashboard.vue";
// @ts-ignore
import Car from "./pages/Car.vue"
// @ts-ignore
import MyCar from "./pages/MyCars.vue"
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard
      // beforeEnter: authGuard
    },
    {
      path: "/cars/user",
      name: "mycars",
      component: MyCar,
      beforeEnter: authGuard
    },
    {
      path: "/cars/:carId",
      name: "car",
      component: Car
    }

  ]
});
