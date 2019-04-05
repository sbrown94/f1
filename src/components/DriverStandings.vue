<template>
    <div class="current-race">
        <h1 class="title">CHAMPIONSHIP STANDINGS</h1>
        <!-- <h2 class="race-title">{{raceTitle}}</h2>
        <h2 class="circuit-name">{{circuitName}}</h2>
        <h2 class="until-start">{{timeToRace}}</h2>
        <div class="flag">
          <img v-bind:src="flagSource" />
        </div> -->
        <div class="driver-standings" v-for="standing in standings">
            <h2 class="driver-standing"><span>{{standing.Driver.code}}</span><span>{{standing.points}}</span></h2>
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

.driver-standings:nth-child(odd) {
    background-color: pink;
}

.driver-standings:nth-child(even) {
    background-color: lightcoral;
}

.driver-standing {
    display: flex;
    justify-content: space-between;
    max-width: 250px;
    margin: 0 auto;
    border-bottom: 1px solid black;
}

.driver-standings {
    padding: 20px;
}
</style>
