<template>
  <div class="my-cars row justify-content-center">
    <div class="col-4 border rounded" v-for="car in cars" :key="car.id">
      <h1>{{car.make}}</h1>
      <h1>{{car.model}}</h1>
    </div>
  </div>
</template>


<script>
export default {
  name: "my-cars",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getMyCars");
  },
  computed: {
    cars() {
      //   return this.$store.state.myCars;
      return this.$store.state.cars;
    }
  },
  methods: {},
  components: {}
};
</script>


<style lang="scss" scoped>
</style>