<template>
  <div class="home">
    <CurrentRace />
    <DriverStandings />
  </div>
</template>

<script>
// @ is an alias to /src
import CurrentRace from '@/components/CurrentRace.vue'
import DriverStandings from '@/components/DriverStandings.vue'

export default {
  name: 'home',
  components: {
    CurrentRace,
    DriverStandings
  }
}
</script>
