// create a Product Class

public class HttpRequest {
	// required
	private final string url;
	// optional
	private final string method;
	private final map<string,string> headers;
	private final map<string,string> queryParams;
	private final string body;
	private final int timeout;

	// private constructor - called by Builder
	private HttpRequest(Builder builder){
		this.url = builder.url;
		this.method = builder.method;
		..... // all parameters assign 
	}

	// Getters (optional for access)
	public string getUrl() { return url } 

	// add static nester Builder class
	public static class Builder {
		// required
		private string url;
		// optional
		private  string method ="GET";
		private  map<string,string> headers = new Map();
		private  map<string,string> queryParams = new Map();
		private  string body;
		private  int timeout=30000;
		public Builder(string url){
			this.url =  url;
		}
		public Builder method(string method){
			this.method =  method;
			return this;
		}
		
		public Builder addHeader(string key,string value){
			this.headers.put(key,value);
			return this;
		}
		
		public Builder addQueryParams(string key,string value){
			this.queryParams.put(key,value);
			return this;
		}

		
		public Builder body(string body){
			this.body = body;
			return this;
		}
		
		public Builder timeout(string timeout){
			this.timeout = timeout;
			return this;
		}
		public HttpRequest build(){
			return new HttpRequest(this);
		}
	}
}

// Builder from CLient Code;

HttpRequest request1 = new HttpRequest.Builder("https://api.com/data").build();

HttpRequest request2 = new HttpRequest.Builder("https://api.com/data")
		.method("POST")
		.body("key","value")
		.timeout(223)
		.build();


