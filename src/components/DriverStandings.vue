<template>
    <div class="current-race">
        <h1 class="title">CHAMPIONSHIP STANDINGS</h1>
        <!-- <h2 class="race-title">{{raceTitle}}</h2>
        <h2 class="circuit-name">{{circuitName}}</h2>
        <h2 class="until-start">{{timeToRace}}</h2>
        <div class="flag">
          <img v-bind:src="flagSource" />
        </div> -->
        <div v-for="standing in standings">
            <h2>{{standing.Driver.code}} - {{standing.points}}</h2>
        </div>
    </div>
</template>

<script>

export default {
  name: 'DriverStandings',
  data: function() {
      return {
          standings: ''
      }
  },
  created: function() {
      this.getRaceData();
  },
  methods: {
      getRaceData() {
          this.$http.get('http://3.8.255.185/api/v1/Race/GetDriverStandings').then(response => {
            this.assignStandingsData(response.body.MRData.StandingsTable.StandingsLists[0].DriverStandings);
          }, error => {
              // error
          });
      },
      assignStandingsData(data) {
          this.standings = data;
      }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.flag {
  width: 50%;
  margin: 0 auto;
}
</style>
