<template>
    <div class="current-race">
        <h1 class="title">CONSTRUCTOR STANDINGS</h1>
        <div class="constructor-standings" v-for="standing in standings" v-bind:style="{ backgroundColor: getTeamColor(standing.Constructor.name) }">
            <h2 class="constructor-standing"><span>{{standing.Constructor.name}}</span><span>{{standing.points}}</span></h2>
        </div>
    </div>
</template>

<script>

export default {
  name: 'ConstructorStandings',
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
      this.$http.get('http://3.8.255.185/api/v1/Race/GetConstructorStandings').then(response => {
        this.assignStandingsData(response.body.MRData.StandingsTable.StandingsLists[0].ConstructorStandings);
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

.constructor-standing {
    display: flex;
    justify-content: space-between;
    max-width: 350px;
    margin: 0 auto;
}

.constructor-standings {
    padding: 20px;
    border-top: 5px solid black;
    color: white;
    text-shadow: 2px 2px 10px black;
    font-size: 24px;
}

.constructor-standings:last-child {
  border-bottom: 5px solid black;
}

</style>
