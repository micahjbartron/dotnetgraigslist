<template>
  <div class="car">
    <div
      class="border rounded shadow"
      @click="$router.push({name: 'carDetails', params: {carId: carData.id}})"
    >
      <h1>{{carData.make}}</h1>
      <h2>{{carData.model}}</h2>
      <img :src="carData.imgUrl" class="img-fluid" />
      <h2>{{carData.price}}</h2>
      <h2>{{carData.year}}</h2>
      <h2>{{carData.body}}</h2>
    </div>
  </div>
</template>

<script>
export default {
  name: "Car",
  props: ["carData"]
}
</script>

<style>
</style>