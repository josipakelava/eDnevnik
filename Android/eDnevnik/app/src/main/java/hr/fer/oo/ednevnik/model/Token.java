package hr.fer.oo.ednevnik.model;

/**
 * Created by luka0 on 23.1.2017..
 */

public class Token {

    private String access_token;

    public Token(String access_token) {
        this.access_token = access_token;
    }

    public String getAccess_token() {
        return access_token;
    }

    public void setAccess_token(String access_token) {
        this.access_token = access_token;
    }
}
