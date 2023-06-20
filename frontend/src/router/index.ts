import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Inventory from "../views/Inventory.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Inventory,
  },
  {
    path: "/inventory",
    name: "Inventory",
    component: Inventory,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
