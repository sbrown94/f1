<template>
    <div class="current-race">
        <h1 class="title">CHAMPIONSHIP STANDINGS</h1>
        <!-- <h2 class="race-title">{{raceTitle}}</h2>
        <h2 class="circuit-name">{{circuitName}}</h2>
        <h2 class="until-start">{{timeToRace}}</h2>
        <div class="flag">
          <img v-bind:src="flagSource" />
        </div> -->
        <div class="driver-standings" v-for="standing in standings" v-bind:style="{ backgroundColor: getTeamColor(standing.Constructors[0].name) }">
            <h2 class="driver-standing">
                <span>{{standing.Driver.code}}</span><span>{{standing.points}}</span>
            </h2>
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
      },
      getTeamColor(team) {
          return this.teamColors[team];
      }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.driver-standing {
    display: flex;
    justify-content: space-between;
    max-width: 250px;
    margin: 0 auto;
}

.driver-standings {
    padding: 20px;
    border-top: 5px solid black;
    color: white;
    text-shadow: 2px 2px 10px black;
    font-size: 24px;
}

</style>
