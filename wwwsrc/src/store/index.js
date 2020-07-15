import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    cars: [],
    // myCars: [],
    activeCar: {}
  },
  mutations: {
    setCars(state, cars) {
      state.cars = cars
    },
    // setMyCars(state, cars) {
    //   state.myCars = cars
    // },
    setCar(state, car) {
      state.activeCar = car
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async createCar({ commit, dispatch }, newCar) {
      let res = await api.post("cars", newCar)
      dispatch("getCars")
    },
    async getCars({ commit, dispatch }) {
      try {
        let res = await api.get("cars")
        commit("setCars", res.data)
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
    async getMyCars({ commit }) {
      let res = await api.get("/cars/user")
      // commit("setMyCars", res.data)
      commit("setCars", res.data)
    },
    async getCar({ commit }, carId) {
      try {
        let res = await api.get("/cars/" + carId)
        console.log("getCar:", res.data)
        commit("setCar", res.data)
      } catch (error) {

      }
    },
    async deleteCar({ dispatch }, carId) {
      try {
        await api.delete("cars/" + carId)
        router.push({ name: "dashboard" })
      } catch (error) {
        alert(JSON.stringify(error.response.data));
      }

    },
    async bidOnCar({ commit }, payload) {
      try {
        let res = await api.put("cars/" + payload.id, payload)
        commit("setCar", res.data)
      } catch (err) {

      }
    }

  }
});
