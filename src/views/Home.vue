<template>
  <div class="home">
    <CurrentRace />
  </div>
</template>

<script>
// @ is an alias to /src
import CurrentRace from '@/components/CurrentRace.vue'

export default {
  name: 'home',
  components: {
    CurrentRace
  }
}
</script>
