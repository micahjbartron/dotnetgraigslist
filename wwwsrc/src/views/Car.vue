<template>
  <div class="car">
    <h1>Make: {{car.make}}</h1>
    <h1>Model: {{car.model}}</h1>
    <img class="img-fluid" :src="car.imgUrl" alt />
    <p>Price: {{car.price}}</p>
    <p>Year: {{car.productionYear}}</p>
    <p>{{car.body}}</p>
    <div class="form-group">
      <label for="bid">Bid Amount:</label>
      <input type="number" class="form-control" name="bid" placeholder="300.00" v-model="bidAmount" />
    </div>
    <button class="btn btn-success btn-block" @click="bid()">Bid</button>
    <button class="btn btn-danger btn-block" @click="deleteCar()">Delete</button>
  </div>
</template>


<script>
export default {
  name: "car",
  data() {
    return {
      bidAmount: 0
    };
  },
  mounted() {
    this.$store.dispatch("getCar", this.$route.params.carId);
  },
  computed: {
    car() {
      return this.$store.state.activeCar;
    }
  },
  methods: {
    deleteCar() {
      this.$store.dispatch("deleteCar", this.car.id);
    },
    bid() {
      let tempCar = JSON.parse(JSON.stringify(this.car));
      tempCar.price = tempCar.price + +this.bidAmount;
      this.$store.dispatch("bidOnCar", tempCar);
    }
  },
  components: {}
};
</script>


<style lang="scss" scoped>
</style>