import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import Car from "./views/Car.vue"
// @ts-ignore
import MyCar from "./views/MyCars.vue"
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
