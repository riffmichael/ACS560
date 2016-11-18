package main

import (
	"fmt"
	"io"
	"net/http"
//	"strconv"	
    "database/sql"
    _ "github.com/lib/pq"
 "encoding/json"
//    "time"

)

const (
    DB_USER     = "postgres"
    DB_PASSWORD = "123456"
    DB_NAME     = "test"
)





type player struct{
Login, Password string
Score int 
Board [32]int
}

func (p *player) getPlayerLogin() string {
return p.Login
}

func (p *player) getPlayerPassword() string {
return p.Password
}

func (p *player) getPlayerScore() int {
return p.Score
}

func (p *player) getBoard() [32]int {
return p.Board
}


type board struct{
candy []string
}

func  pullboard(datastuffs *sql.DB) [32]int {

rows1, err1 := datastuffs.Query("SELECT value FROM boards where id=1")
    checkErr(err1)

    for rows1.Next() {
//        var uid int
        var value string
//        var department string
//        var created time.Time
        err1 = rows1.Scan(&value)
        checkErr(err1)
//        fmt.Println("uid | username | department | created <br>")
        fmt.Println(value)
}
//how do i parse a string of coma seperated numbers to an int array?
//var someboard = [32] int value
var someboard = [32] int {3,1,1,2,2,3,1,2,2,4,3,1,3,1,2,2,3,1,1,2,2,3,1,2,2,2,3,4,3,1,2,2}
return someboard
}

func databaseConnect() *sql.DB {

    dbinfo := fmt.Sprintf("user=%s password=%s dbname=%s sslmode=disable",
        DB_USER, DB_PASSWORD, DB_NAME)
    db, err := sql.Open("postgres", dbinfo)
    checkErr(err)
//    defer db.Close()
    rows, err := db.Query("SELECT value FROM boards where id=1")
    checkErr(err)

    for rows.Next() {
//        var uid int
        var value string
//        var department string
//        var created time.Time
        err = rows.Scan(&value)
        checkErr(err)
//        fmt.Println("uid | username | department | created <br>")
//        fmt.Println(value)
//        fmt.Println("<br>")

        }

return db

}

func checkErr(err error) {
    if err != nil {
        panic(err)
fmt.Println("error has occoured")
    }
}





func listenServer(w http.ResponseWriter, r *http.Request) {
io.WriteString(w, "t")
}

func loginServer(w http.ResponseWriter, r *http.Request) {
//io.WriteString(w, "ok, login?")

var newBoard = [32] int {3,1,1,2,2,3,1,2,2,4,3,1,3,1,2,2,3,1,1,2,2,3,1,2,2,2,3,4,3,1,2,2}

newPlayer := player{Login: r.URL.Query()["user"][0], Password: r.URL.Query()["pass"][0], Score: 0, Board: newBoard}

pullboard(databaseConnect())
json.NewEncoder(w).Encode(newPlayer)


}

func createUser(w http.ResponseWriter, r *http.Request) {
io.WriteString(w, "createing user")
newPlayer := player{Login: r.URL.Query()["user"][0], Password: r.URL.Query()["pass"][0]}
fmt.Println("login: ", newPlayer.getPlayerLogin())
fmt.Println("password: ", newPlayer.getPlayerPassword())


}

func getNextBoard(w http.ResponseWriter, r *http.Request) {

i := r.URL.Query()["board"][0]
next := "nextBoard: " + i
io.WriteString(w, next)

fmt.Println("current: ", i)
fmt.Println("next: ", i)
}






func main() {



http.HandleFunc("/login", loginServer)
http.HandleFunc("/new", createUser)
http.HandleFunc("/nextBoard", getNextBoard)
http.ListenAndServe(":80", nil)

}
